using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_TestViewModel : BaseWindowViewModel<Base_TestDTO>
    {
        public Base_TestViewModel() : base("Base_Manage", typeof(Base_TestEditViewModel), typeof(Base_TestEdit), "")
        {

        }

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override void Edit(Base_TestDTO para = null)
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

        protected override void Search(object para = null)
        {
            base.Search(para);
        }
    }
}
