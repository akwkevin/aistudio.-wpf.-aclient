using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Quartz_Manage.ViewModels
{
    public class Quartz_TaskEditViewModel : BaseEditViewModel<Quartz_TaskDTO>
    {
        private List<string> _jobOptions;
        public List<string> JobOptions
        {
            get { return _jobOptions; }
            set
            {
                SetProperty(ref _jobOptions, value);
            }
        }
        protected override async Task GetData(object option)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                await base.GetData(option);
                await GetJobOptions();
            }
        }

        protected async Task GetJobOptions()
        {
            try
            {
                var result = await _dataProvider.GetData<List<string>>($"/Quartz_Manage/Quartz_Task/GetJobOptions");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                JobOptions = result.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
            }
        }
    }
}

