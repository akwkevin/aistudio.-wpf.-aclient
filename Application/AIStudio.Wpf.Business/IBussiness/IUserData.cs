using AIStudio.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{
    public interface IUserData
    {
        Task<ObservableCollection<ISelectOption>> GetAllUser();
        void ClearAllUser();
        Task<ObservableCollection<ISelectOption>> GetAllRole();
        void ClearAllRole();
        Task<ObservableCollection<ISelectOption>> GetAllTreeDepartment();
        Task<ObservableCollection<ISelectOption>> GetAllDepartment();
        void ClearAllDepartment();
        Task<ObservableCollection<DictionaryTreeModel>> GetAllDictionary();
        void ClearAllDictionary();
        Dictionary<string, ObservableCollection<ISelectOption>> Items { get; }
        Dictionary<string, DictionaryTreeModel> Dictionarys { get;  }
        Task Init();
    }
}
