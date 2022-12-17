using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Core.Helpers;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
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
using Prism.Commands;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Crypto.Engines;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseListViewModel<TData, EditForm> : NavigationDockWindowViewModel where TData : class, IIsChecked where EditForm : ChildWindow
    {
        protected IDataProvider _dataProvider { get { return ContainerLocator.Current.Resolve<IDataProvider>(); } }

        public string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }

        protected string GetDataList { get; set; } = "GetDataList";


        private string _condition;
        public string Condition
        {
            get { return _condition; }
            set
            {
                SetProperty(ref _condition, value);
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

        private ObservableCollection<TData> _data;
        public ObservableCollection<TData> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }


        private TData _selectedItem;
        public TData SelectedItem
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
                return this._addCommand ?? (this._addCommand = new DelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new DelegateCommand<TData>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(async () => await this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _printCommand;
        public ICommand PrintCommand
        {
            get
            {
                return this._printCommand ?? (this._printCommand = new DelegateCommand(() => this.Print()));
            }
        }

        private ICommand _deleteOneCommand;
        public ICommand DeleteOneCommand
        {
            get
            {
                return this._deleteOneCommand ?? (this._deleteOneCommand = new DelegateCommand<string>(async para => await this.Delete(para)));
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return this._refreshCommand ?? (this._refreshCommand = new DelegateCommand(() => this.Search()));
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return this._searchCommand ?? (this._searchCommand = new DelegateCommand(() => this.Search()));
            }
        }

        private ICommand _currentIndexChangedComamnd;
        public ICommand CurrentIndexChangedComamnd
        {
            get
            {
                return this._currentIndexChangedComamnd ?? (this._currentIndexChangedComamnd = new DelegateCommand<object>(para => this.Search(para)));
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

        protected virtual string GetDataJson()
        {
            var searchKeyValues = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(Condition) && !string.IsNullOrEmpty(KeyWord))
            {
                searchKeyValues.Add(Condition, KeyWord);
            }

            var data = new
            {
                PageIndex = Pagination.PageIndex,
                PageRows = Pagination.PageRows,
                SortField = Pagination.SortField,
                SortType = Pagination.SortType,
                SearchKeyValues = searchKeyValues,
            };

            return JsonConvert.SerializeObject(data);
        }

        protected virtual async Task GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var result = await _dataProvider.GetData<List<TData>>($"/{Area}/{typeof(TData).Name.Replace("DTO", "")}/{GetDataList}", GetDataJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<TData>(result.Data);
                    if (Data.Any())
                    {
                        SelectedItem = Data.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected virtual async void Edit(TData para = null)
        {
            var dialog = CreateView<string>(para?.Id, Area, Identifier);
            if (dialog is ChildWindow childwindow)
            {
                var res = (DialogResult)await WindowBase.ShowChildWindowAsync(childwindow, "编辑表单", Identifier);
                if (res == DialogResult.OK)
                {
                    await GetData();
                }
            }
        }

        #region
        public virtual ChildWindow CreateView<Options>(Options option, string area, string identifier)
        {
            var dialog = Activator.CreateInstance<EditForm>() as ChildWindow;
            var viewmodel = GetEditViewModel();
            viewmodel.Options = option;
            viewmodel.Area = area;
            viewmodel.Identifier = identifier;

            dialog.ValidationActionAsync += () => { return viewmodel.ValidationAsync(); };
            dialog.Loaded += async (sender, e) => { await viewmodel.OnLoaded(sender, e); };
            dialog.Unloaded += async (sender, e) => { await viewmodel.OnUnloaded(sender, e); };
            dialog.DataContext = viewmodel;

            return dialog;
        }

        protected virtual BaseEditViewModel2<TData> GetEditViewModel()
        {
            return new BaseEditViewModel2<TData>();
        }
        #endregion

        protected virtual async Task Delete(string id = null)
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
            var sure = await MessageBoxDialog.Show("确认删除吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(TData).Name.Replace("DTO", "")}/DeleteData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Error(ex.Message);
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
                string fullClassName = $"AIStudio.Wpf.{Area}.ViewModels.{typeof(TData).Name.Replace("DTO", "")}DocumentRenderer";

                //根据类名称创建类实例
                var type = System.Reflection.Assembly.Load($"AIStudio.Wpf.{Area}").GetType(fullClassName);

                PrintPreviewWindow previewWnd = new PrintPreviewWindow($"/AIStudio.Wpf.{Area};component/Views/{typeof(TData).Name.Replace("DTO", "")}FlowDocument.xaml", data, Activator.CreateInstance(type) as IDocumentRenderer);
                previewWnd.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
            }
        }

        protected virtual void Search(object para = null)
        {
            Pagination.PageIndex = 0;
            GetData();
        }

        protected BaseListViewModel()
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
        }

        public override async Task OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await GetData();
        }

    }
}
