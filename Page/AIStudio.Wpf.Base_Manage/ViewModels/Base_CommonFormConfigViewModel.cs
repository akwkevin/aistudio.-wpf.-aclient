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

        protected override async Task GetData(bool iswaiting = false)
        {
            await base.GetData(iswaiting);
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Base_CommonFormConfigEditViewModel();
        }

        protected override void Edit(Base_CommonFormConfigDTO para = null)
        {
            base.Edit(para);
        }      

        protected override async Task Delete(string id = null)
        {
            await base.Delete(id);
        }

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
