using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IBase_AppSecretBusiness : IBaseBusiness<Base_AppSecret>
    {  
        Task<PageResult<Base_AppSecret>> GetDataListAsync(PageInput<AppSecretsInputDTO> input);     
        Task<Base_AppSecret> GetTheDataAsync(IdInputDTO input);
        Task<string> GetAppSecretAsync(string appId);
  
        Task AddDataAsync(Base_AppSecret newData);
        Task UpdateDataAsync(Base_AppSecret theData);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDataAsync(Base_AppSecret theData);
    }

    public class AppSecretsInputDTO
    {
        public string keyword { get; set; }
    }
}