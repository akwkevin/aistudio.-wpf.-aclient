using AIStudio.Core;
using AIStudio.Wpf.DataBusiness.AOP;
using AIStudio.Wpf.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IBase_DatasourceBusiness : IBaseBusiness<Base_Datasource>
    {  
        Task<PageResult<Base_Datasource>> GetDataListAsync(PageInput<Base_DatasourceInputDTO> input);     
        Task<Base_Datasource> GetTheDataAsync(IdInputDTO input);
  
        Task AddDataAsync(Base_Datasource newData);
        Task UpdateDataAsync(Base_Datasource theData);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDataAsync(Base_Datasource theData);
    }

    public class Base_DatasourceInputDTO
    {
        public string keyword { get; set; }
    }
}