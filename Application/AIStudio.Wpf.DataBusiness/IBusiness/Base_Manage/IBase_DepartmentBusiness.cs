using AIStudio.Core;
using AIStudio.Wpf.EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.DataBusiness.Base_Manage
{
    public interface IBase_DepartmentBusiness : IBaseBusiness<Base_Department>
    {
        Task<List<Base_DepartmentTreeDTO>> GetTreeDataListAsync(DepartmentsTreeInputDTO input);
        Task<Base_Department> GetTheDataAsync(string id);
        Task<List<string>> GetChildrenIdsAsync(string departmentId);
        Task AddDataAsync(Base_Department newData);
        Task UpdateDataAsync(Base_Department theData);
        Task DeleteDataAsync(List<string> ids);
        Task SaveDataAsync(Base_Department theData);
    }

    public class DepartmentsTreeInputDTO
    {
        public string parentId { get; set; }
    }

    public class Base_DepartmentTreeDTO : TreeModel
    {
        public new object children { get => Children; }
        public string title { get => Text; }
        public string value { get => Id; }
        public string key { get => Id; }
        public string ParentIds { get; set; }
    }
}