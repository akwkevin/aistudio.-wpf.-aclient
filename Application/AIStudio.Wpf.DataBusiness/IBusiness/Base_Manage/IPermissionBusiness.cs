using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IPermissionBusiness
    {
        Task<List<string>> GetUserPermissionValuesAsync(string userId);
        Task<List<Base_ActionDTO>> GetUserMenuListAsync(string userId);
    }
}
