using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;

namespace AIStudio.Wpf.Quartz_Manage.ViewModels
{
    public class Quartz_TaskEditViewModel : BaseEditViewModel<Quartz_TaskDTO>
    {
        public Quartz_TaskEditViewModel(Quartz_TaskDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
            if (Data == null)
            {
                InitData();
            }
            else
            {
                GetData(Data);
            }
        }

		protected override void InitData()
		{
			Data = new Quartz_TaskDTO();
		}

        protected override void GetData(Quartz_TaskDTO para)
        {
            base.GetData(para);
        }       
    }
}
