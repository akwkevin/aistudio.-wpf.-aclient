using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.IAppClient;
using AIStudio.Wpf.Service.ITempService;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.TempService
{
    public class UserData: IUserData
    {
        IDataProvider _dataProvider { get; }
        public UserData()
        {
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();

        }

        private List<Base_UserEasy> alluser { get; set; }

        private List<Base_RoleEasy> allrole { get; set; }

        private List<TreeModel> alldepartment { get; set; }

        public async Task<List<Base_UserEasy>> GetAllUser()
        {
            if (alluser == null)
            {
                var result = await _dataProvider.GetData<List<Base_UserEasy>>("/Base_Manage/Base_User/GetAllEasyDataList");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    alluser = result.ResponseItem;
                }
            }

            return alluser;
        }

        public void ClearAllUser()
        {
            alluser = null;
        }

        public async Task<List<Base_RoleEasy>> GetAllRole()
        {
            if (allrole == null)
            {
                var result = await _dataProvider.GetData<List<Base_RoleEasy>>("/Base_Manage/Base_Role/GetAllEasyDataList");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    allrole = result.ResponseItem;
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
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    alldepartment = result.ResponseItem;                  
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
