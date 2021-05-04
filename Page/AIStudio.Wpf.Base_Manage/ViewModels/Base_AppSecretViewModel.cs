using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.EFCore.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_AppSecretViewModel : BaseWindowViewModel<Base_AppSecretDTO>
    {
        public Base_AppSecretViewModel():base("Base_Manage", typeof(Base_AppSecretEditViewModel), typeof(Base_AppSecretEdit))
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override void Edit(Base_AppSecretDTO para = null)
        {
            base.Edit(para);
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
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
