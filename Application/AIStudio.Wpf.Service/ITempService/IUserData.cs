using AIStudio.Wpf.Business.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Service.ITempService
{
    public interface IUserData
    {
        Task<List<Base_UserEasy>> GetAllUser();
        void ClearAllUser();
        Task<List<Base_RoleEasy>> GetAllRole();
        void ClearAllRole();
        Task<List<TreeModel>> GetAllDepartment();
        void ClearAllDepartment();
    }
}
