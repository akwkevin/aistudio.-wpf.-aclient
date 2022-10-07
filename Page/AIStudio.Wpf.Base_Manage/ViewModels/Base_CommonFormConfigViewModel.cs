using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_CommonFormConfigViewModel : BaseWindowViewModel<Base_CommonFormConfigDTO>
    {
        public Base_CommonFormConfigViewModel():base("Base_Manage", typeof(Base_CommonFormConfigEditViewModel), typeof(Base_CommonFormConfigEdit), "Table")
        {
		
        }        

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override void Edit(Base_CommonFormConfigDTO para = null)
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
