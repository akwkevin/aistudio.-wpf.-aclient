using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DbLinkViewModel : BaseWindowViewModel<Base_DbLinkDTO>
    {
        public Base_DbLinkViewModel():base("Base_Manage", typeof(Base_AppSecretEditViewModel), typeof(Base_DbLinkEdit))
        {

        }

        protected override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override void Edit(Base_DbLinkDTO para = null)
        {
            base.Edit(para);
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
