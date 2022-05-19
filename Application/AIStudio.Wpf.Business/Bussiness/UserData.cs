using AIStudio.Core;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{
    public class UserData: IUserData
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
        }
    }
}
