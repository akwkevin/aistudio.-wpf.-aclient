using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DatasourceViewModel : BaseWindowViewModel<Base_DatasourceDTO>
    {
        public Base_DatasourceViewModel():base("Base_Manage", typeof(Base_DatasourceEditViewModel), typeof(Base_DatasourceEdit))
        {
		
        }        

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override void Edit(Base_DatasourceDTO para = null)
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
