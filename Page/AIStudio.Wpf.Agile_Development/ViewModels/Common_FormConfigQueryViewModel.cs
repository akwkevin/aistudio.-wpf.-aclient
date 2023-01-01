using AIStudio.Core;
using AIStudio.Wpf.Agile_Development.Commons;
using AIStudio.Wpf.Agile_Development.Converter;
using AIStudio.Wpf.Agile_Development.Views;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.PrismAvalonExtensions.ViewModels;
using Newtonsoft.Json;
using org.mariuszgromada.math.mxparser.parsertokens;
using Prism.Commands;
using Prism.Common;
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
        protected string Name { get; set; }

        protected string ConfigUrl { get; set; } = "/Base_Manage/Base_CommonFormConfig/GetDataList";
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
                RaisePropertyChanged(nameof(IsNew));
            }
        }

        public Core.Models.Pagination Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 100 };

        protected string IdName { get; set; } = "Id";
        public bool IsNew { get { return SelectedItem == null || !SelectedItem.ContainsKey(IdName) || string.IsNullOrEmpty(((IDictionary<string, object>)SelectedItem)[IdName]?.ToString()); } }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => ((dynamic)p).IsChecked) > 0));
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(() => this.Add()));
            }
        }

        private ICommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                return this._copyCommand ?? (this._copyCommand = new DelegateCommand(() => this.Copy()));
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

        protected virtual async void GetConfig()
        {
            try
            {
                var data = new
                {
                    PageIndex = 0,
                    PageRows = 500,
                    SearchKeyValues = new Dictionary<string, object>()
                    {
                        {"Table", Name }
                    }
                };

                var result = await _dataProvider.PostData<List<Base_CommonFormConfigDTO>>(ConfigUrl, JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }

                QueryConditionItems = new ObservableCollection<QueryConditionItem>(result.Data.Where(p => p.Type == 0).OrderBy(p => p.DisplayIndex).Select((p, index) => GetQueryConditionItem(p)));
                QueryConditionItems.Add(new QueryConditionItem() { Header = "新增", ControlType = Core.ControlType.Add, Visibility = System.Windows.Visibility.Visible });
                QueryConditionItems.Add(new QueryConditionItem() { Header = "复制", ControlType = Core.ControlType.Copy, Visibility = System.Windows.Visibility.Visible });
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

            return data.ToJson();
        }

        protected virtual async Task GetData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.PostData<List<ExpandoObject>>($"/{Area}/{Name}/{GetDataList}", GetDataJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    else
                    {
                        Pagination.Total = result.Total;
                        result.Data.ForEach(p => ((dynamic)p).IsChecked = false);
                        Data = new ObservableCollection<ExpandoObject>(result.Data);

                        if (SelectedItem != null && SelectedItem.ContainsKey(IdName))
                        {
                            SelectedItem = Data.FirstOrDefault(p => ((IDictionary<string, object>)p)[IdName] == ((IDictionary<string, object>)SelectedItem)[IdName]);
                        }
                        else if (Data?.Any() == true)
                        {
                            SelectedItem = Data.FirstOrDefault();
                        }
                        else
                        {
                            SelectedItem = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        public async void Submit()
        {
            var title = SelectedItem == null ? "新增数据" : "修改数据";
            var content = SelectedItem == null ? "确定要提交新增数据？" : "确定要提交修改数据？";
            var sure = await MessageBoxDialog.Show(content, title, ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
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
                    Controls.MessageBox.Error(((dynamic)obj).Error);
                }

                await SaveData(obj);
            }
        }

        protected virtual async Task SaveData(ExpandoObject para)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.PostData<AjaxResult>($"/{Area}/{Name}/SaveData", para.ToJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    await GetData();
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        protected virtual async void Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => ((dynamic)p).IsChecked).Select(p => ((IDictionary<string, object>)p)[IdName]?.ToString()));
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
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    try
                    {
                        var result = await _dataProvider.PostData<AjaxResult>($"/{Area}/{Name}/DeleteData", JsonConvert.SerializeObject(ids));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        await GetData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }
            }
        }


        protected virtual async void Search(object para = null)
        {
            await GetData();
        }

        protected virtual void Add()
        {
            SelectedItem = null;
        }

        protected virtual void Copy()
        {
            var idItem = EditFormItems.FirstOrDefault(p => p.PropertyName == IdName);
            if (idItem != null)
                idItem.Value = null;
            _selectedItem = null;//不要触发EditFormItems赋值事件
            RaisePropertyChanged(nameof(IsNew));
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
            await base.OnLoaded(sender, e);
            if (Data == null)
            {
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    GetConfig();
                    await GetData();
                }
            }
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
