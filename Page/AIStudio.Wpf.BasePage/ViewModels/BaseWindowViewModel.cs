using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Core.Helpers;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseWindowViewModel<T> : NavigationDockWindowViewModel where T : class, IIsChecked
    {
        protected IDataProvider _dataProvider { get; }
        public BaseWindowViewModel(string area, Type type, Type editType, string getDataList = "GetDataList")
        {
            Area = area;
            GetDataList = getDataList;
            Type = type;
            EditType = editType;

            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }

        protected string GetDataList { get; set; }

        protected Type Type { get; set; }
        protected Type EditType { get; set; }

        private string _condition;
        public string Condition
        {
            get { return _condition; }
            set
            {
                SetProperty(ref _condition, value);
            }
        }

        private ComboBoxItem _conditionItem;
        public ComboBoxItem ConditionItem
        {
            get { return _conditionItem; }
            set
            {
                SetProperty(ref _conditionItem, value);
            }
        }

        private string _keyWord;
        public string KeyWord
        {
            get { return _keyWord; }
            set
            {
                SetProperty(ref _keyWord, value);
            }
        }

        public Dictionary<string, object> SearchKeyValues { get; set; } = new Dictionary<string, object>();

        private ObservableCollection<T> _data;
        public ObservableCollection<T> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }


        private T _selectedItem;
        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }




        public Core.Models.Pagination Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 100 };

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new CanExecuteDelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<T>(para => this.Edit(para)));
            }
        }

        private ICommand _viewCommand;
        public ICommand ViewCommand
        {
            get
            {
                return this._viewCommand ?? (this._viewCommand = new CanExecuteDelegateCommand<T>(para => this.View(para), para => para != null));
            }
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _printCommand;
        public ICommand PrintCommand
        {
            get
            {
                return this._printCommand ?? (this._printCommand = new CanExecuteDelegateCommand(() => this.Print()));
            }
        }

        private ICommand _deleteOneCommand;
        public ICommand DeleteOneCommand
        {
            get
            {
                return this._deleteOneCommand ?? (this._deleteOneCommand = new CanExecuteDelegateCommand<string>(para => this.Delete(para)));
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return this._refreshCommand ?? (this._refreshCommand = new CanExecuteDelegateCommand(() => this.Search()));
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return this._searchCommand ?? (this._searchCommand = new CanExecuteDelegateCommand(() => this.Search()));
            }
        }

        private ICommand _currentIndexChangedComamnd;
        public ICommand CurrentIndexChangedComamnd
        {
            get
            {
                return this._currentIndexChangedComamnd ?? (this._currentIndexChangedComamnd = new CanExecuteDelegateCommand<object>(para => this.Search(para)));
            }
        }

        protected void ShowWait()
        {
            WindowBase.ShowWaiting(WaitingStyle.Progress, Identifier, "正在获取数据");
        }

        protected void HideWait()
        {
            WindowBase.HideWaiting(Identifier);
        }

        protected virtual async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var data = new
                {
                    PageIndex = Pagination.PageIndex,
                    PageRows = Pagination.PageRows,
                    SortField = Pagination.SortField,
                    SortType = Pagination.SortType,
                    Search = new
                    {
                        keyword = KeyWord,
                        condition = ConditionItem?.Tag,
                    },
                    SearchKeyValues = SearchKeyValues,
                };

                var result = await _dataProvider.GetData<List<T>>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/{GetDataList}", JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<T>(result.Data);
                    if (Data.Any())
                    {
                        SelectedItem = Data.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected virtual BaseEditViewModel<T> GetEditViewModel(T para = null)
        {
            return Activator.CreateInstance(Type, new object[] { para, Area, Identifier, "编辑表单" }) as BaseEditViewModel<T>;
        }

        protected virtual bool ValidationEdit(BaseEditViewModel<T> viewmodel)
        {
            if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                throw new Exception(viewmodel.Data.Error);
            else
                return true;
        }

        protected virtual async void Edit(T para = null)
        {
            var viewmodel = GetEditViewModel(para);
            var dialog = Activator.CreateInstance(EditType, new object[] { viewmodel }) as BaseDialog;
            dialog.ValidationAction = (() =>
            {
                return ValidationEdit(viewmodel);
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                await SaveData(viewmodel.Data);
            }
        }

        protected virtual async Task SaveData(T para)
        {
            try
            {
                ShowWait();
                var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/SaveData", JsonConvert.SerializeObject(para));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                GetData(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                HideWait();
            }
        }



        protected virtual async void View(T para)
        {
            var viewmodel = Activator.CreateInstance(Type, new object[] { para, Area, Identifier, "查看表单" }) as BaseEditViewModel<T>;
            var dialog = Activator.CreateInstance(EditType, new object[] { viewmodel }) as BaseDialog;
            var fButton = dialog.FindName("PART_AffirmativeButton") as Button;
            fButton.Visibility = System.Windows.Visibility.Collapsed;
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);

        }

        protected virtual async void Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }

            await Delete(ids);
        }

        protected virtual async Task Delete(List<string> ids)
        {
            var sure = await MessageBoxDialog.Warning("确认删除吗?", "提示", Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/DeleteData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    HideWait();
                }
            }
        }



        protected virtual void Print()
        {
            Print(Data);
        }

        protected virtual void Print(System.Collections.IList data)
        {
            try
            {
                string fullClassName = $"AIStudio.Wpf.{Area}.ViewModels.{typeof(T).Name.Replace("DTO", "")}DocumentRenderer";

                //根据类名称创建类实例
                var type = System.Reflection.Assembly.Load($"AIStudio.Wpf.{Area}").GetType(fullClassName);

                PrintPreviewWindow previewWnd = new PrintPreviewWindow($"/AIStudio.Wpf.{Area};component/Views/{typeof(T).Name.Replace("DTO", "")}FlowDocument.xaml", data, Activator.CreateInstance(type) as IDocumentRenderer);
                previewWnd.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void Search(object para = null)
        {
            GetData();
        }



        protected BaseWindowViewModel()
        {

        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }

            Initialize();
        }

        public override void Initialize()
        {
            if (IsInitialize)
            {
                return;
            }
            base.Initialize();
            GetData();
        }

    }
}
