using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using NPOI.SS.Formula.PTG;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DbLinkViewModel : BaseListWithEditViewModel<Base_DbLinkDTO, Base_DbLinkEdit>
    {
        public Base_DbLinkViewModel()
        {
            Area = "Base_Manage";
            Condition = "LinkName";
            NewTitle = "新建连接";
            EditTitle = "编辑连接";
        }

        protected override async Task GetData(bool iswaiting = false)
        {
            await base.GetData(iswaiting);
        }

        protected override BaseEditViewModel<Base_DbLinkDTO> GetEditViewModel()
        {
            return new Base_DbLinkEditViewModel();
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
