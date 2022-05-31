using AIStudio.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business
{
    public interface IUserData
    {
        Task<ObservableCollection<ISelectOption>> GetBase_User();
        void ClearBase_User();
        Task<ObservableCollection<ISelectOption>> GetBase_Role();
        void ClearBase_Role();
        Task<ObservableCollection<ISelectOption>> GetBase_DepartmentTree();
        Task<ObservableCollection<ISelectOption>> GetBase_Department();
        void ClearBase_Department();
        Task<ObservableCollection<ISelectOption>> GetBase_ActionTree();
        Task<ObservableCollection<ISelectOption>> GetBase_Action();
        void ClearBase_Action();
        Task<ObservableCollection<DictionaryTreeModel>> GetBase_Dictionary();
        void ClearBase_Dictionary();
        Dictionary<string, ObservableCollection<ISelectOption>> ItemSource { get; }
        Dictionary<string, DictionaryTreeModel> Base_Dictionary { get;  }
        Task Init();
    }
}
