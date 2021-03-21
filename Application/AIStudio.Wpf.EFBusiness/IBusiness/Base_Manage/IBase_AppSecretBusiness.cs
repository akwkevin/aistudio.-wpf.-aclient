using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.EFBusiness.Base_Manage
{
    public interface IBase_AppSecretBusiness : IBaseBusiness<Base_AppSecret>
    {
        Task<PageResult<Base_AppSecret>> GetDataListAsync(PageInput<AppSecretsInputDTO> input);
        Task<Base_AppSecret> GetTheDataAsync(string id);
        Task<string> GetAppSecretAsync(string appId);
        Task AddDataAsync(Base_AppSecret newData);
        Task UpdateDataAsync(Base_AppSecret theData);
        Task DeleteDataAsync(List<string> ids);
    }

    public class AppSecretsInputDTO
    {
        public string keyword { get; set; }
    }
}