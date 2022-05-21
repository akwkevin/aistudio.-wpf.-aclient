using AIStudio.Core;
using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.AgileDevelopment.Attributes;
using AIStudio.Wpf.AgileDevelopment.Commons;
using AIStudio.Wpf.Entity.DTOModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AIStudio.Wpf.AgileDevelopment.Views;

namespace AIStudio.Wpf.AgileDevelopment.ViewModels
{
    class CommonQueryViewModel<T, Q> : BaseWindowViewModel<T> where T : class, IIsChecked, new()
    {
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

        private string _header;
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                SetProperty(ref _header, value);
            }
        }

        public ObservableCollection<DataGridColumnCustom> DataGridColumns
        {
            get; private set;
        } = new ObservableCollection<DataGridColumnCustom>();

        public ObservableCollection<QueryConditionItem> QueryConditionItems
        {
            get; private set;
        } = new ObservableCollection<QueryConditionItem>();

        public ObservableCollection<EditFormItem> EditFormItems
        {
            get; private set;
        } = new ObservableCollection<EditFormItem>();

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

        public CommonQueryViewModel(string area, Type type, string getDataList = "GetDataList") : base(area, type, typeof(CommonQueryEdit), getDataList)
        {
            var properties_query = typeof(Q).GetProperties();
            var queryConditionItems = new List<QueryConditionItem>();
            foreach (System.Reflection.PropertyInfo info in properties_query)
            {
                QueryConditionItem queryConditionItem = QueryConditionItem.GetQueryConditionItem(info);
                if (queryConditionItem != null)
                {
                    queryConditionItems.Add(queryConditionItem);
                }
            }
            queryConditionItems.OrderBy(p => p.DisplayIndex).ToList().ForEach(p => QueryConditionItems.Add(p));

            QueryConditionItems.Add(new QueryConditionItem() { Header = "新增", ControlType = ControlType.Add, Visibility = System.Windows.Visibility.Visible });
            QueryConditionItems.Add(new QueryConditionItem() { Header = "删除", ControlType = ControlType.Delete, Visibility = System.Windows.Visibility.Visible });
            QueryConditionItems.Add(new QueryConditionItem() { Header = "查询", ControlType = ControlType.Query, Visibility = System.Windows.Visibility.Visible });

            var properties = typeof(T).GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                DataGridColumnCustom dataGridColumnCustom = ColumnHeaderAttribute.GetDataGridColumnCustom(info);
                if (dataGridColumnCustom != null)
                {
                    DataGridColumns.Add(dataGridColumnCustom);
                }
            }

            var editFormItems = new List<EditFormItem>();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                EditFormItem editFormItem = EditFormItem.GetEditFormItem(info);
                if (editFormItem != null)
                {
                    editFormItems.Add(editFormItem);
                }
            }
            editFormItems.OrderBy(p => p.DisplayIndex).ToList().ForEach(p => EditFormItems.Add(p));
            EditFormItems.Add(new EditFormItem() { Header = "提交", ControlType = ControlType.Submit, Visibility = System.Windows.Visibility.Visible });

            //Query();

            this.PropertyChanged += CommonQueryViewModel_PropertyChanged;              
        }



        public override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override void GetData(bool iswaiting = false)
        {
            #region 后台没有支持按字段进行筛选的查询,暂时没有处理
            //var dic = QueryConditionItem.ListToDictionary(QueryConditionItems);
            #endregion

            base.GetData(iswaiting);
        }

        public async void Submit()
        {
            var obj = SelectedItem;
            if (obj == null)
            {
                obj = new T();
            }      

            BaseControlItem.ListToObject(obj, EditFormItems);
            if (!string.IsNullOrEmpty(obj.Error))
            {
                throw new Exception(obj.Error);
            }

            await SaveData(obj);
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

        protected override BaseEditViewModel<T> GetEditViewModel(T para = null)
        {
            return Activator.CreateInstance(Type, new object[] { EditFormItems.Where(p => p.ControlType != ControlType.Submit), para, Area, Identifier, "编辑表单" }) as BaseEditViewModel<T>;
        }

        protected override bool ValidationEdit(BaseEditViewModel<T> viewmodel)
        {
            BaseControlItem.ListToObject(viewmodel.Data, EditFormItems);
            return base.ValidationEdit(viewmodel);
        }
    }
}

