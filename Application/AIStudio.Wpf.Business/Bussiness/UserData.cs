using AIStudio.Core;
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

        private ObservableCollection<ISelectOption> alluser { get; set; }

        private ObservableCollection<ISelectOption> allrole { get; set; }

        private ObservableCollection<ISelectOption> alldepartment { get; set; }

        private ObservableCollection<ISelectOption> alltreedepartment { get; set; }

        private ObservableCollection<DictionaryTreeModel> alldictionary { get; set; }

        public async Task<ObservableCollection<ISelectOption>> GetAllUser()
        {
            if (alluser == null)
            {
                var result = await _dataProvider.GetData<ObservableCollection<SelectOption>>("/Base_Manage/Base_User/GetOptionList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    alluser = new ObservableCollection<ISelectOption>(result.Data);
                }
            }

            return alluser;
        }

        public void ClearAllUser()
        {
            alluser = null;
        }

        public async Task<ObservableCollection<ISelectOption>> GetAllRole()
        {
            if (allrole == null)
            {
                var result = await _dataProvider.GetData<ObservableCollection<SelectOption>>("/Base_Manage/Base_Role/GetOptionList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    allrole = new ObservableCollection<ISelectOption>(result.Data);
                }
            }

            return allrole;
        }

        public void ClearAllRole()
        {
            allrole = null;
        }

        public async Task<ObservableCollection<ISelectOption>> GetAllTreeDepartment()
        {
            if (alltreedepartment == null)
            {
                var result = await _dataProvider.GetData<ObservableCollection<TreeModel>>("/Base_Manage/Base_Department/GetTreeDataList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    alltreedepartment = new ObservableCollection<ISelectOption>(result.Data);
                }
            }

            return alltreedepartment;
        }

        public async Task<ObservableCollection<ISelectOption>> GetAllDepartment()
        {
            if (alldepartment == null)
            {
                var tree = await GetAllTreeDepartment();
                alldepartment = new ObservableCollection<ISelectOption>(TreeHelper.GetTreeToList(tree.Select(p => p as TreeModel)));
            }

            return alldepartment;
        }

        public void ClearAllDepartment()
        {
            alltreedepartment = null;
            alldepartment = null;
        }

        public async Task<ObservableCollection<DictionaryTreeModel>> GetAllDictionary()
        {
            if (alldictionary == null)
            {
                var result = await _dataProvider.GetData<ObservableCollection<DictionaryTreeModel>>("/Base_Manage/Base_Dictionary/GetMenuTreeList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    alldictionary = new ObservableCollection<DictionaryTreeModel>(result.Data);
                }
            }

            return alldictionary;
        }

        public void ClearAllDictionary()
        {
            alldictionary = null;
        }

        public Dictionary<string, ObservableCollection<ISelectOption>> Items { get; private set; } = new Dictionary<string, ObservableCollection<ISelectOption>>();
        public Dictionary<string, DictionaryTreeModel> Dictionarys { get; private set; } = new Dictionary<string, DictionaryTreeModel>();

        public async Task Init()
        {
            Items.Add("User", await GetAllUser());
            Items.Add("Role", await GetAllRole());
            Items.Add("Department", await GetAllDepartment());
            Items.Add("TreeDepartment", await GetAllTreeDepartment());
            var datas = await GetAllDictionary();
            BuildDictionary(Items, Dictionarys, datas);
        }

        public static void BuildDictionary(Dictionary<string, ObservableCollection<ISelectOption>> items, Dictionary<string, DictionaryTreeModel> dics, IEnumerable<DictionaryTreeModel> trees)
        {
            foreach (var tree in trees)
            {
                if (tree.Type == 0)
                {
                    dics.Add(tree.Value, tree);

                    var datas = tree.Children.Where(p => p.Type == 1);
                    if (datas.Count() > 0)
                    {
                        items.Add(tree.Value, new ObservableCollection<ISelectOption>(datas.Select(p => new SelectOption() { Value = p.Value, Text = p.Text })));
                    }

                    var subtrees = tree.Children.Where(p => p.Type == 0);
                    if (subtrees.Count() > 0)
                    {
                        BuildDictionary(items, dics, subtrees);
                    }
                }
            }
        }
    }
}