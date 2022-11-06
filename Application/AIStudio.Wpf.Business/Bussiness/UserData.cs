using AIStudio.Core;
using NPOI.HSSF.Record;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{
    public class UserData : IUserData
    {
        IDataProvider _dataProvider { get; }
        public UserData()
        {
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();

        }

        public string[] ReadOnlySource { get; } = new string[] { "Id", "CreateTime", "ModifyTime", "CreatorName", "ModifyName" };
        public string[] IgnoreSource { get; } = new string[] { "IsChecked", "Deleted", "CreatorId", "ModifyId", };

        private ObservableCollection<ISelectOption> base_user { get; set; } = new ObservableCollection<ISelectOption>();

        private ObservableCollection<ISelectOption> base_role { get; set; } = new ObservableCollection<ISelectOption>();

        private ObservableCollection<ISelectOption> base_department { get; set; } = new ObservableCollection<ISelectOption>();

        private ObservableCollection<ISelectOption> base_departmenttree { get; set; } = new ObservableCollection<ISelectOption>();

        private ObservableCollection<ISelectOption> base_action { get; set; } = new ObservableCollection<ISelectOption>();

        private ObservableCollection<ISelectOption> base_actiontree { get; set; } = new ObservableCollection<ISelectOption>();

        private ObservableCollection<DictionaryTreeModel> base_dictionary { get; set; } = new ObservableCollection<DictionaryTreeModel>();

        public async Task<ObservableCollection<ISelectOption>> GetBase_User()
        {
            if (base_user.Count == 0)
            {
                var result = await _dataProvider.GetData<ObservableCollection<SelectOption>>("/Base_Manage/Base_User/GetOptionList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    base_user.AddRange(result.Data);
                }
            }

            return base_user;
        }

        public void ClearBase_User()
        {
            base_user.Clear();
        }

        public async Task<ObservableCollection<ISelectOption>> GetBase_Role()
        {
            if (base_role.Count == 0)
            {
                var result = await _dataProvider.GetData<ObservableCollection<SelectOption>>("/Base_Manage/Base_Role/GetOptionList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    base_role.AddRange(result.Data);
                }
            }

            return base_role;
        }

        public void ClearBase_Role()
        {
            base_role.Clear();
        }

        public async Task<ObservableCollection<ISelectOption>> GetBase_DepartmentTree()
        {
            if (base_departmenttree.Count == 0)
            {
                var result = await _dataProvider.GetData<ObservableCollection<TreeModel>>("/Base_Manage/Base_Department/GetTreeDataList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    base_departmenttree.AddRange(result.Data);
                }
            }

            return base_departmenttree;
        }

        public async Task<ObservableCollection<ISelectOption>> GetBase_Department()
        {
            if (base_department.Count == 0)
            {
                var tree = await GetBase_DepartmentTree();
                base_department.AddRange(TreeHelper.GetTreeToList(tree.Select(p => p as TreeModel)));
            }

            return base_department;
        }

        public void ClearBase_Department()
        {
            base_departmenttree.Clear();
            base_department.Clear();
        }

        public async Task<ObservableCollection<ISelectOption>> GetBase_ActionTree()
        {
            if (base_actiontree.Count == 0)
            {
                var result = await _dataProvider.GetData<ObservableCollection<TreeModel>>("/Base_Manage/Base_Action/GetActionTreeList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    base_actiontree.AddRange(result.Data);
                }
            }

            return base_actiontree;
        }

        public async Task<ObservableCollection<ISelectOption>> GetBase_Action()
        {
            if (base_action.Count == 0)
            {
                var tree = await GetBase_ActionTree();
                base_action.AddRange(TreeHelper.GetTreeToList(tree.Select(p => p as TreeModel)));
            }

            return base_action;
        }

        public void ClearBase_Action()
        {
            base_actiontree.Clear();
            base_action.Clear();
        }

        public async Task<ObservableCollection<DictionaryTreeModel>> GetBase_Dictionary()
        {
            if (base_dictionary.Count == 0)
            {
                var result = await _dataProvider.GetData<ObservableCollection<DictionaryTreeModel>>("/Base_Manage/Base_Dictionary/GetTreeDataList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    base_dictionary.AddRange(result.Data);
                }
            }

            return base_dictionary;
        }

        public void ClearBase_Dictionary()
        {
            base_dictionary.Clear();
        }

        public Dictionary<string, ObservableCollection<ISelectOption>> ItemSource { get; private set; } = new Dictionary<string, ObservableCollection<ISelectOption>>();
        public Dictionary<string, DictionaryTreeModel> Base_Dictionary { get; private set; } = new Dictionary<string, DictionaryTreeModel>();

        public async Task Init()
        {
            ClearBase_User();
            ClearBase_Role();
            ClearBase_Department();
            ClearBase_Dictionary();
            ClearBase_Action();

            ItemSource.Clear();
            Base_Dictionary.Clear();
            ItemSource.Add("Base_User", await GetBase_User());
            ItemSource.Add("Base_Role", await GetBase_Role());
            ItemSource.Add("Base_Department", await GetBase_Department());
            ItemSource.Add("Base_DepartmentTree", await GetBase_DepartmentTree());
            ItemSource.Add("Base_Action", await GetBase_Action());
            ItemSource.Add("Base_ActionTree", await GetBase_ActionTree());
            var datas = await GetBase_Dictionary();
            BuildDictionary(ItemSource, Base_Dictionary, datas);
        }

        public static void BuildDictionary(Dictionary<string, ObservableCollection<ISelectOption>> items, Dictionary<string, DictionaryTreeModel> dics, IEnumerable<DictionaryTreeModel> trees)
        {
            foreach (var tree in trees)
            {
                if (tree.Type == 0)
                {
                    dics.Add(tree.Value, tree);
                }

                if (tree.Children?.Count > 0)
                {
                    var datas = tree.Children.Where(p => p.Type == 1);
                    if (datas.Count() > 0)
                    {
                        items.Add(tree.Value, new ObservableCollection<ISelectOption>(datas.Select(p => new SelectOption() { Value = p.Value, Text = p.Text, Remark = p.Remark })));
                    }

                    foreach (var item in tree.Children)
                    {
                        BuildDictionary(items, dics, tree.Children);
                    }
                }
            }
        }

      
    }
}