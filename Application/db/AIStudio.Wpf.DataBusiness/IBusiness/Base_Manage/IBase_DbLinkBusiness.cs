using AIStudio.Core;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IBase_DbLinkBusiness : IBaseBusiness<Base_DbLink>
    {
        Task<PageResult<Base_DbLink>> GetDataListAsync(PageInput input);
        Task<Base_DbLink> GetTheDataAsync(IdInputDTO input);
        Task AddDataAsync(Base_DbLink newData);
        Task UpdateDataAsync(Base_DbLink theData);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDataAsync(Base_DbLink theData);
    }
}