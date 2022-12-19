using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Quartz_Manage.ViewModels
{
    public class Quartz_TaskEditViewModel : BaseEditViewModel<Quartz_TaskDTO>
    {
        List<string> JobOptions { get; set; } = new List<string>();

        protected override async Task GetData(object option)
        {
            await base.GetData(option);

        }
    }
}
  
