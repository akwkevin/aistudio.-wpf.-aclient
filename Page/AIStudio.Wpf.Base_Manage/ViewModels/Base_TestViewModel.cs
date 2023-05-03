using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_TestViewModel : BaseListWithEditViewModel<Base_TestDTO, Base_TestEdit>
    {
        public Base_TestViewModel()
        {
		    Area = "Base_Manage";
        }      
        
        protected override async Task GetData()
        {
            await base.GetData();
        }

        protected override void Edit(Base_TestDTO para = null)
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

        protected override void Search(object para = null)
        {
            base.Search(para);
        }     
    }
}
