using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_AppSecretViewModel : BaseListWithEditViewModel<Base_AppSecretDTO, Base_AppSecretEdit>
    {
        public Base_AppSecretViewModel()
        {
            Area = "Base_Manage";
            Condition = "AppName";
            NewTitle = "新建密钥";
            EditTitle = "编辑密钥";
        }

        protected override async Task GetData(bool iswaiting = false)
        {
            await base.GetData(iswaiting);
        }

        protected override void Edit(Base_AppSecretDTO para = null)
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
