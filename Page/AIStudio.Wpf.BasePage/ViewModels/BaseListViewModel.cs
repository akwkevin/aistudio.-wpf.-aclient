using AIStudio.Core;
using AIStudio.Core.Helpers;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BaseListViewModel<TData> : NavigationDockWindowViewModel where TData : class, IIsChecked 
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
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(async () => await this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
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
            WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");
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

                var result = await _dataProvider.GetData<List<TData>>($"/{Area}/{typeof(TData).Name.Replace("DTO", "").Replace("Tree","")}/{GetDataList}", GetDataJson());
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

        protected virtual void Edit(TData para = null)
        {
          
        }      

        protected virtual async Task Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked == true).Select(p => p.Id));
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

                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{typeof(TData).Name.Replace("DTO", "").Replace("Tree", "")}/DeleteData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    await GetData(true);
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

        protected virtual async void Search(object para = null)
        {
            Pagination.PageIndex = 0;
            await GetData();
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
            await base.OnLoaded(sender, e);
            await GetData();
        }

        public override async Task OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await base.OnUnloaded(sender, e);
            Dispose();
        }
    }
}
