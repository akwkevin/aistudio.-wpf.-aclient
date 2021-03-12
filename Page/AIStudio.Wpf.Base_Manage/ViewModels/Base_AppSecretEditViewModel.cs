using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_AppSecretEditViewModel : BaseEditViewModel<Base_AppSecretDTO>
    {
        public Base_AppSecretEditViewModel(Base_AppSecretDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            if (Data == null)
            {
                Data = new Base_AppSecretDTO();
            }
            else
            {
                GetData(Data);
            }
        }

        protected override void GetData(Base_AppSecretDTO para)
        {
            base.GetData(para);
        }       
    }
}
