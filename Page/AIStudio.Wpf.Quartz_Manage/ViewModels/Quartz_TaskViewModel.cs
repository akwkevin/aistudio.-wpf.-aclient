using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.Quartz_Manage.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AIStudio.Wpf.Quartz_Manage.ViewModels
{
    public class Quartz_TaskViewModel : BaseWindowViewModel<Quartz_TaskDTO>
    {
        private ICommand _pauseCommand;
        public ICommand PauseCommand
        {
            get
            {
                return this._pauseCommand ?? (this._pauseCommand = new CanExecuteDelegateCommand(() => this.Pause(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new CanExecuteDelegateCommand(() => this.Start(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _toDoCommand;
        public ICommand ToDoCommand
        {
            get
            {
                return this._toDoCommand ?? (this._toDoCommand = new CanExecuteDelegateCommand(() => this.ToDo(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _editFirstCommand;
        public ICommand EditFirstCommand
        {
            get
            {
                return this._editFirstCommand ?? (this._editFirstCommand = new CanExecuteDelegateCommand(() => this.EditFirst(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _logCommand;
        public ICommand LogCommand
        {
            get
            {
                return this._logCommand ?? (this._logCommand = new CanExecuteDelegateCommand<Quartz_TaskDTO>(para => this.Log(para)));
            }
        }

        public Quartz_TaskViewModel():base("Quartz_Manage", typeof(Quartz_TaskEditViewModel), typeof(Quartz_TaskEdit))
        {
	
        }

        public override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override void GetData(bool iswaiting = false)
        {
            base.GetData(iswaiting);
        }

        protected override void Edit(Quartz_TaskDTO para = null)
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

        protected override void Search(object para=null)
        {
            base.Search(para);
        }

        private async void Pause()
        {
            List<string> ids = Data.Where(p => p.IsChecked).Select(p => p.Id).ToList();

            var sure = await MessageBoxDialog.Warning("确认暂停吗?", "提示", Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/Quartz_Manage/Quartz_Task/PauseData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    HideWait();
                }
            }
        }

        private async void Start()
        {
            List<string> ids = Data.Where(p => p.IsChecked).Select(p => p.Id).ToList();

            var sure = await MessageBoxDialog.Warning("确认开始吗?", "提示", Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/Quartz_Manage/Quartz_Task/StartData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    HideWait();
                }
            }
        }

        private async void ToDo()
        {
            List<string> ids = Data.Where(p => p.IsChecked).Select(p => p.Id).ToList();

            var sure = await MessageBoxDialog.Warning("确认立即执行吗?", "提示", Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/Quartz_Manage/Quartz_Task/ToDoData", JsonConvert.SerializeObject(ids));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    HideWait();
                }
            }
        }

        private void EditFirst()
        {
            var para = Data.FirstOrDefault(p => p.IsChecked);
            Edit(para);
        }

        private async void Log(Quartz_TaskDTO para)
        {
            Quartz_TaskLogViewModel viewModel = new Quartz_TaskLogViewModel(para.GroupName + "." + para.TaskName, Identifier);
            Quartz_TaskLog dialog = new Quartz_TaskLog(viewModel);
            await WindowBase.ShowDialogAsync(dialog, Identifier);
        }
    }
}
