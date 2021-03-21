using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.EFBusiness.Base_Manage
{
    public interface IBase_DbLinkBusiness : IBaseBusiness<Base_DbLink>
    {
        Task<PageResult<Base_DbLink>> GetDataListAsync(PageInput input);
        Task<Base_DbLink> GetTheDataAsync(string id);
        Task AddDataAsync(Base_DbLink newData);
        Task UpdateDataAsync(Base_DbLink theData);
        Task DeleteDataAsync(List<string> ids);
    }
}