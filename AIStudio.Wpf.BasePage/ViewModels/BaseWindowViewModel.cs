using AIStudio.Core;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.IAppClient;
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
using Util.Controls;
using Util.Controls.DialogBox;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseWindowViewModel<T> : NavigationDockWindowViewModel where T : class, IIsChecked
    {
        protected IDataProvider _dataProvider { get; }
        public BaseWindowViewModel(string area, Type type, Type editType, string getDataList="GetDataList")
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

        private ObservableCollection<T> _data;
        public ObservableCollection<T> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
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

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
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
            var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
            control.WaitInfo = "正在获取数据";
        }

        protected void HideWait()
        {
            Util.Controls.WindowBase.HideWaiting(Identifier);
        }

        protected virtual async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", Pagination.PageIndex.ToString());
                data.Add("PageRows", Pagination.PageRows.ToString());
                data.Add("SortField", Pagination.SortField ?? "Id");
                data.Add("SortType", Pagination.SortType);
                data.Add("keyword", KeyWord ?? "");
                data.Add("condition", ConditionItem != null ? ConditionItem.Tag.ToString() : "");

                var result = await _dataProvider.GetData<List<T>>($"/{Area}/{typeof(T).Name.Replace("DTO","")}/{GetDataList}", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<T>(result.ResponseItem);
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

        protected virtual async void Edit(T para = null)
        {
            var viewmodel = Activator.CreateInstance(Type, new object[] { para, Area, "编辑表单" }) as BaseEditViewModel<T>;
            var dialog = Activator.CreateInstance(EditType, new object[] { viewmodel }) as BaseDialog;
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();                 
                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.IsOK)
                    {
                        throw new Exception(result.ErrorMessage);
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

            var sure = await Msg.Warning("确认删除吗?", BoxType.Metro, Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("ids", JsonConvert.SerializeObject(ids));

                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(T).Name.Replace("DTO", "")}/DeleteData", data);
                    if (!result.IsOK)
                    {
                        throw new Exception(result.ErrorMessage);
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

        protected virtual void Initialize()
        {
            
        }

    }
}
