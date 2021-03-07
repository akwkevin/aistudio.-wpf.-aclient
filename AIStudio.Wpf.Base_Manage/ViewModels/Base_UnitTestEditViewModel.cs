using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_UnitTestEditViewModel : BaseEditViewModel<Base_UnitTestDTO>
    {
        public Base_UnitTestEditViewModel(Base_UnitTestDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            if (Data == null)
            {
                Data = new Base_UnitTestDTO();
            }
            else
            {
                GetData(Data);
            }
        }

        protected override void GetData(Base_UnitTestDTO para)
        {
            base.GetData(para);
        }       
    }
}
