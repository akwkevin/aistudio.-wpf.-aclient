using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DbLinkViewModel : BaseWindowViewModel<Base_DbLinkDTO>
    {
        public Base_DbLinkViewModel():base("Base_Manage", typeof(Base_DbLinkEditViewModel), typeof(Base_DbLinkEdit), "LinkName")
        {

        }

        protected override async Task GetData(bool iswaiting = false)
        {
            await base.GetData(iswaiting);
        }

        protected override void Edit(Base_DbLinkDTO para = null)
        {
            base.Edit(para);
        }

        protected override async Task Delete(string id = null)
        {
            await base.Delete(id);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
