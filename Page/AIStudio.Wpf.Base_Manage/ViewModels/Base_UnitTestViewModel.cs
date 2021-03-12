using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_UnitTestViewModel : BaseWindowViewModel<Base_UnitTestDTO>
    {
        public Base_UnitTestViewModel():base("Base_Manage", typeof(Base_UnitTestEditViewModel),typeof(Base_UnitTestEdit))
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

        protected override void Edit(Base_UnitTestDTO para = null)
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
