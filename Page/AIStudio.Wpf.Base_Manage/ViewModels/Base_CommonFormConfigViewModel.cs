using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_CommonFormConfigViewModel : BaseListWithEditViewModel<Base_CommonFormConfigDTO, Base_CommonFormConfigEdit>
    {
        public Base_CommonFormConfigViewModel()
        {
            Area = "Base_Manage";
            Condition = "Table";
            NewTitle = "新建表单";
            EditTitle = "编辑表单";
        }        

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_CommonFormConfigEditViewModel();
        }       
    }
}
