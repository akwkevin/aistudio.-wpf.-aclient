using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Controls.Commands;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Quartz_Manage.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIStudio.Wpf.Quartz_Manage.ViewModels
{
    public class Quartz_TaskViewModel : BaseListWithEditViewModel<Quartz_TaskDTO, Quartz_TaskEdit>
    {
        private ICommand _pauseCommand;
        public ICommand PauseCommand
        {
            get
            {
                return this._pauseCommand ?? (this._pauseCommand = new CanExecuteDelegateCommand(() => this.Pause(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new CanExecuteDelegateCommand(() => this.Start(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        private ICommand _toDoCommand;
        public ICommand ToDoCommand
        {
            get
            {
                return this._toDoCommand ?? (this._toDoCommand = new CanExecuteDelegateCommand(() => this.ToDo(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        private ICommand _editFirstCommand;
        public ICommand EditFirstCommand
        {
            get
            {
                return this._editFirstCommand ?? (this._editFirstCommand = new CanExecuteDelegateCommand(() => this.EditFirst(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        private ICommand _logCommand;
        public ICommand LogCommand
        {
            get
            {
                return this._logCommand ?? (this._logCommand = new DelegateCommand<Quartz_TaskDTO>(para => this.Log(para)));
            }
        }

        private ICommand _pauseOneCommand;
        public ICommand PauseOneCommand
        {
            get
            {
                return this._pauseOneCommand ?? (this._pauseOneCommand = new DelegateCommand<string>(para => this.Pause(para)));
            }
        }

        private ICommand _startOneCommand;
        public ICommand StartOneCommand
        {
            get
            {
                return this._startOneCommand ?? (this._startOneCommand = new DelegateCommand<string>(para => this.Start(para)));
            }
        }

        private ICommand _toDoOneCommand;
        public ICommand ToDoOneCommand
        {
            get
            {
                return this._toDoOneCommand ?? (this._toDoOneCommand = new DelegateCommand<string>(para => this.ToDo(para)));
            }
        }

        public Quartz_TaskViewModel()
        {
            Area = "Quartz_Manage";
            Condition = "TaskName";
            NewTitle = "新建任务";
            EditTitle = "编辑任务";
        }

        protected override async Task GetData()
        {
            await base.GetData();
        }

        protected override IBaseEditViewModel GetEditViewModel()
        {
            return new Quartz_TaskEditViewModel();
        }

        protected override void Edit(Quartz_TaskDTO para = null)
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

        protected async void Pause(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }

            var sure = await MessageBoxDialog.Show("确认暂停吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    try
                    {
                        var result = await _dataProvider.GetData<AjaxResult>($"/Quartz_Manage/Quartz_Task/PauseData", JsonConvert.SerializeObject(ids));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        await GetData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }
            }
        }

        private async void Start(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }            

            var sure = await MessageBoxDialog.Show("确认开始吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    try
                    {
                        var result = await _dataProvider.GetData<AjaxResult>($"/Quartz_Manage/Quartz_Task/StartData", JsonConvert.SerializeObject(ids));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        await GetData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }
            }
        }

        private async void ToDo(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked == true).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }

            var sure = await MessageBoxDialog.Show("确认立即执行吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
                {
                    try
                    {
                        var result = await _dataProvider.GetData<AjaxResult>($"/Quartz_Manage/Quartz_Task/ToDoData", JsonConvert.SerializeObject(ids));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        await GetData();
                    }
                    catch (Exception ex)
                    {
                        Controls.MessageBox.Error(ex.Message);
                    }
                }
            }
        }

        private void EditFirst()
        {
            var para = Data.FirstOrDefault(p => p.IsChecked  == true);
            Edit(para);
        }

        private async void Log(Quartz_TaskDTO para)
        {
            Quartz_TaskLog dialog = new Quartz_TaskLog() { DataContext = new Quartz_TaskLogViewModel(para.GroupName + "." + para.TaskName, Identifier) };
            await WindowBase.ShowChildWindowAsync(dialog, "查看日志", Identifier);
        }
    }
}
