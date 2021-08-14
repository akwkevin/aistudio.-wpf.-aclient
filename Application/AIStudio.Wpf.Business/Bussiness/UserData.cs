using AIStudio.Core;
using Prism.Ioc;
using System;
using System.Collections.Generic;
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

        private List<SelectOption> alluser { get; set; }

        private List<SelectOption> allrole { get; set; }

        private List<TreeModel> alldepartment { get; set; }

        public async Task<List<SelectOption>> GetAllUser()
        {
            if (alluser == null)
            {
                var result = await _dataProvider.GetData<List<SelectOption>>("/Base_Manage/Base_User/GetOptionList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    alluser = result.Data;
                }
            }

            return alluser;
        }

        public void ClearAllUser()
        {
            alluser = null;
        }

        public async Task<List<SelectOption>> GetAllRole()
        {
            if (allrole == null)
            {
                var result = await _dataProvider.GetData<List<SelectOption>>("/Base_Manage/Base_Role/GetOptionList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    allrole = result.Data;
                }
            }

            return allrole;
        }

        public void ClearAllRole()
        {
            allrole = null;
        }

        public async Task<List<TreeModel>> GetAllDepartment()
        {
            if (alldepartment == null)
            {
                var result = await _dataProvider.GetData<List<TreeModel>>("/Base_Manage/Base_Department/GetTreeDataList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    alldepartment = result.Data;                  
                }
            }

            return alldepartment;
        }
        public void ClearAllDepartment()
        {
            alldepartment = null;
        }
    }
}
