using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.EFCore.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DbLinkEditViewModel : BaseEditViewModel<Base_DbLinkDTO>
    {
        public Base_DbLinkEditViewModel(Base_DbLinkDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            if (Data == null)
            {
                Data = new Base_DbLinkDTO();
            }
            else
            {
                GetData(Data);
            }
        }

        protected override void GetData(Base_DbLinkDTO para)
        {
            base.GetData(para);
        }       
    }
}
