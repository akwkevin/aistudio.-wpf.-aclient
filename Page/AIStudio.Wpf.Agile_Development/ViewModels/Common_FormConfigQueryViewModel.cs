using AIStudio.Core;
using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Agile_Development.Converter;
using AIStudio.Wpf.Agile_Development.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using Newtonsoft.Json;
using org.mariuszgromada.math.mxparser.parsertokens;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AIStudio.Wpf.Agile_Development.ViewModels
{
    public class Common_FormConfigQueryViewModel : NavigationDockWindowViewModel
    {
        protected IDataProvider _dataProvider { get; }
        protected IUserData _userData { get; }

        public Common_FormConfigQueryViewModel()
        {
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();
            _userData = ContainerLocator.Current.Resolve<IUserData>();

            this.PropertyChanged += CommonQueryViewModel_PropertyChanged;
        }

        protected string Identifier { get; set; } = LocalSetting.RootWindow;
        protected string Area { get; set; }
        public string Name { get; set; }
        public string ConfigUrl { get; set; } = "/Base_Manage/Base_CommonFormConfig/GetDataList";

        protected string GetDataList { get; set; } = "GetDataList";

        private bool _queryConditionConfigIsOpen;
        public bool QueryConditionConfigIsOpen
        {
            get
            {
                return _queryConditionConfigIsOpen;
            }
            set
            {
                SetProperty(ref _queryConditionConfigIsOpen, value);
            }
        }

        private ObservableCollection<DataGridColumnCustom> _dataGridColumns = new ObservableCollection<DataGridColumnCustom>();
        public ObservableCollection<DataGridColumnCustom> DataGridColumns
        {
            get { return _dataGridColumns; }
            set
            {
                SetProperty(ref _dataGridColumns, value);
            }
        }

        private ObservableCollection<QueryConditionItem> _queryConditionItems = new ObservableCollection<QueryConditionItem>();
        public ObservableCollection<QueryConditionItem> QueryConditionItems
        {
            get { return _queryConditionItems; }
            set
            {
                SetProperty(ref _queryConditionItems, value);
            }
        }

        private ObservableCollection<EditFormItem> _editFormItems = new ObservableCollection<EditFormItem>();
        public ObservableCollection<EditFormItem> EditFormItems
        {
            get { return _editFormItems; }
            set
            {
                SetProperty(ref _editFormItems, value);
            }
        }

        private ObservableCollection<ExpandoObject> _data;
        public ObservableCollection<ExpandoObject> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }


        private ExpandoObject _selectedItem;
        public ExpandoObject SelectedItem
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
                return this._editCommand ?? (this._editCommand = new DelegateCommand<ExpandoObject>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => ((dynamic)p).IsChecked) > 0));
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

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return this._submitCommand ?? (this._submitCommand = new DelegateCommand(() => this.Submit()));
            }
        }

        private ICommand _queryConditionConfigCommand;
        public ICommand QueryConditionConfigCommand
        {
            get
            {
                return this._queryConditionConfigCommand ?? (this._queryConditionConfigCommand = new DelegateCommand(() => this.QueryConditionConfig()));
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

        public void QueryConditionConfig()
        {
            QueryConditionConfigIsOpen = true;
        }

        private void CommonQueryViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                BaseControlItem.ObjectToList(SelectedItem, EditFormItems);
            }
        }

        protected virtual async void GetConfig(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var data = new
                {
                    PageIndex = 0,
                    PageRows = 500,
                    Search = new
                    {
                        keyword = Name,
                        condition = "Table",
                    }
                };

                var result = await _dataProvider.GetData<List<Base_CommonFormConfigDTO>>(ConfigUrl, JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }

                QueryConditionItems = new ObservableCollection<QueryConditionItem>(result.Data.Where(p => p.Type == 0).OrderBy(p => p.DisplayIndex).Select((p, index) => GetQueryConditionItem(p)));
                QueryConditionItems.Add(new QueryConditionItem() { Header = "新增", ControlType = Core.ControlType.Add, Visibility = System.Windows.Visibility.Visible });
                QueryConditionItems.Add(new QueryConditionItem() { Header = "删除", ControlType = Core.ControlType.Delete, Visibility = System.Windows.Visibility.Visible });
                QueryConditionItems.Add(new QueryConditionItem() { Header = "查询", ControlType = Core.ControlType.Query, Visibility = System.Windows.Visibility.Visible });

                DataGridColumns = new ObservableCollection<DataGridColumnCustom>(result.Data.Where(p => p.Type == 1).OrderBy(p => p.DisplayIndex).Select((p, index) => GetDataGridColumnCustom(p)));
                EditFormItems = new ObservableCollection<EditFormItem>(result.Data.Where(p => p.Type == 1).OrderBy(p => p.DisplayIndex).Select((p, index) => GetEditFormItem(p)));
                EditFormItems.Add(new EditFormItem() { Header = "提交", ControlType = Core.ControlType.Submit, Visibility = System.Windows.Visibility.Visible });
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }


        protected virtual string GetDataJson()
        {
            var data = new
            {
                PageIndex = Pagination.PageIndex,
                PageRows = Pagination.PageRows,
                SortField = Pagination.SortField,
                SortType = Pagination.SortType,
                SearchKeyValues = QueryConditionItem.ListToDictionary(QueryConditionItems),
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

                var result = await _dataProvider.GetData<List<ExpandoObject>>($"/{Area}/{Name}/{GetDataList}", GetDataJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    result.Data.ForEach(p => ((dynamic)p).IsChecked = false);
                    Data = new ObservableCollection<ExpandoObject>(result.Data);
                    if (Data.Any())
                    {
                        SelectedItem = Data.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected virtual async void Edit(ExpandoObject para = null)
        {
            var viewmodel = new Common_FormConfigQueryEditViewModel(EditFormItems.Where(p => p.ControlType != ControlType.Submit), para, Area, Name, Identifier, "编辑表单");
            var dialog = new Common_QueryEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                BaseControlItem.ListToObject(viewmodel.Data, viewmodel.EditFormItems);
                if (!string.IsNullOrEmpty(((dynamic)viewmodel.Data).Error))
                    throw new Exception(((dynamic)viewmodel.Data).Error);
                else
                    return true;
            });
            var res = (DialogResult)await WindowBase.ShowChildWindowAsync(dialog, "编辑表单", Identifier);
            if (res == DialogResult.OK)
            {
                await SaveData(viewmodel.Data);
            }
        }

        public async void Submit()
        {
            ExpandoObject obj;
            if (SelectedItem == null)
            {
                obj = new ExpandoObject();
            }
            else
            {
                obj = SelectedItem.DeepClone();
            }

            BaseControlItem.ListToObject(obj, EditFormItems);
            if (!string.IsNullOrEmpty(((dynamic)obj).Error))
            {
                throw new Exception(((dynamic)obj).Error);
            }

            await SaveData(obj);
        }

        protected virtual async Task SaveData(ExpandoObject para)
        {
            try
            {
                ShowWait();
                var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{Name}/SaveData", JsonConvert.SerializeObject(para));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                GetData(true);
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                HideWait();
            }
        }

        protected virtual async void Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => ((dynamic)p).IsChecked).Select(p => (string)((dynamic)p).Id));
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

                    var result = await _dataProvider.GetData<AjaxResult>($"/{Area}/{Name}/DeleteData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
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

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }
            var value = navigationContext.Parameters["Value"] as string;
            var items = value.Split(".");
            Area = items[0];
            Name = items[1];
        }

        public override async Task OnLoaded(object sender, RoutedEventArgs e)
        {
            GetConfig();
            await GetData();
        }

        private DataGridColumnCustom GetDataGridColumnCustom(Base_CommonFormConfigDTO config)
        {
            var itemsource = config.ItemSource ?? config.PropertyName;

            DataGridColumnCustom item = new DataGridColumnCustom();
            item.Header = config.Header;
            item.PropertyName = config.PropertyName;
            item.StringFormat = config.StringFormat;
            item.Visibility = config.Visibility;
            item.SortMemberPath = config.SortMemberPath;
            item.Converter = config.Converter;
            item.ConverterParameter = config.ConverterParameter ?? config.ItemSource ?? config.PropertyName;
            item.HorizontalAlignment = config.HorizontalAlignment;
            item.MaxWidth = config.MaxWidth;
            item.MinWidth = config.MinWidth;
            item.Width = StringToLength(config.Width);
            item.CanUserReorder = config.CanUserReorder;
            item.CanUserResize = config.CanUserResize;
            item.CanUserSort = config.CanUserSort;
            item.CellStyle = config.CellStyle;
            item.HeaderStyle = config.HeaderStyle;
            item.BackgroundExpression = config.BackgroundExpression;
            item.ForegroundExpression = config.ForegroundExpression;
            if (string.IsNullOrEmpty(config.Converter))
            {
                if (_userData.ItemSource.ContainsKey(itemsource))
                {
                    item.Converter = typeof(ObjectToStringConverter).Name;
                    item.ConverterParameter = itemsource;                  
                }
            }
            return item;
        }

        private EditFormItem GetEditFormItem(Base_CommonFormConfigDTO config)
        {
            EditFormItem item = new EditFormItem();
            GetBaseControlItem(item, config);

            return item;
        }

        private QueryConditionItem GetQueryConditionItem(Base_CommonFormConfigDTO config)
        {
            QueryConditionItem item = new QueryConditionItem();
            GetBaseControlItem(item, config);

            return item;
        }

        private void GetBaseControlItem(BaseControlItem item, Base_CommonFormConfigDTO config)
        {
            var itemsource = config.ItemSource ?? config.PropertyName;

            item.Header = config.Header;
            item.PropertyName = config.PropertyName;
            item.Value = config.Value;
            item.Visibility = config.Visibility;
            item.ControlType = config.ControlType;
            item.IsRequired = config.IsRequired;
            item.StringFormat = config.StringFormat;
            item.IsReadOnly = config.IsReadOnly;
            item.Regex = config.Regex;
            item.ErrorMessage = config.ErrorMessage;

            if (!string.IsNullOrEmpty(itemsource))
            {
                if (_userData.ItemSource.ContainsKey(itemsource))
                {
                    //树形控件使用树形数据集
                    if (config.ControlType == Core.ControlType.TreeSelect || config.ControlType == Core.ControlType.MultiTreeSelect)
                    {
                        item.ItemSource = _userData.ItemSource[$"{itemsource}Tree"];
                    }
                    else
                    {
                        item.ItemSource = _userData.ItemSource[itemsource];
                    }
                }
            }

            if (!string.IsNullOrEmpty(config.PropertyType))
            {
                if (config.PropertyType.ToLower() == "int" || config.PropertyType.ToLower() == "int?")
                {
                    if (string.IsNullOrEmpty(config.StringFormat))
                    {
                        item.StringFormat = "n0";
                    }
                    if (item.ControlType == Core.ControlType.None)
                    {
                        item.ControlType = Core.ControlType.IntegerUpDown;
                    }
                }
                else if (config.PropertyType.ToLower() == "long" || config.PropertyType.ToLower() == "long?")
                {
                    if (string.IsNullOrEmpty(item.StringFormat))
                    {
                        item.StringFormat = "n0";
                    }
                    if (item.ControlType == Core.ControlType.None)
                    {
                        item.ControlType = Core.ControlType.LongUpDown;
                    }
                }
                else if (config.PropertyType.ToLower() == "double" || config.PropertyType.ToLower() == "double?")
                {
                    if (string.IsNullOrEmpty(item.StringFormat))
                    {
                        item.StringFormat = "f3";
                    }
                    if (item.ControlType == Core.ControlType.None)
                    {
                        item.ControlType = Core.ControlType.DoubleUpDown;
                    }
                }
                else if (config.PropertyType.ToLower() == "decimal" || config.PropertyType.ToLower() == "decimal?")
                {
                    if (string.IsNullOrEmpty(item.StringFormat))
                    {
                        item.StringFormat = "f3";
                    }
                    if (item.ControlType == Core.ControlType.None)
                    {
                        item.ControlType = Core.ControlType.DecimalUpDown;
                    }
                }
                else if (config.PropertyType.ToLower() == "datetime" || config.PropertyType.ToLower() == "datetime?")
                {
                    if (string.IsNullOrEmpty(item.StringFormat))
                    {
                        item.StringFormat = "yyyy-MM-dd HH:mm:ss";
                    }
                    if (item.ControlType == Core.ControlType.None)
                    {
                        item.ControlType = Core.ControlType.DateTimeUpDown;
                    }
                }
            }

            if (item.ControlType == Core.ControlType.None)
            {
                item.ControlType = Core.ControlType.TextBox;
            }
        }

        private DataGridLength StringToLength(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return new DataGridLength(0, DataGridLengthUnitType.Auto);
                }
                else if (str.ToLower() == "auto")
                {
                    return new DataGridLength(0, DataGridLengthUnitType.Auto);
                }
                if (str == "*")
                {
                    return new DataGridLength(1, DataGridLengthUnitType.Star);
                }
                else if (str.Contains("*"))
                {
                    return new DataGridLength(double.Parse(str.Replace("*", "")), DataGridLengthUnitType.Star);
                }
                else
                {
                    return new DataGridLength(double.Parse(str), DataGridLengthUnitType.Pixel);
                }
            }
            catch
            {
                return new DataGridLength(0, DataGridLengthUnitType.Auto);
            }
        }
    }
}
