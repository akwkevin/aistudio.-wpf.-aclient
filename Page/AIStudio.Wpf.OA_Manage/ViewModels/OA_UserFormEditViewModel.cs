using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AIStudio.Wpf.Controls;
using System.Collections.ObjectModel;
using AIStudio.Wpf.GridControls.ViewModel;
using AIStudio.Wpf.BasePage.Models;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_UserFormEditViewModel : BaseEditViewModel<OA_UserFormDTO>
    {
        private int _status = 100;
        public int Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
            }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set
            {
                SetProperty(ref _remark, value);
            }
        }

        private ICommand _openEditorCommand;
        public ICommand OpenEditorCommand
        {
            get
            {
                return this._openEditorCommand ?? (this._openEditorCommand = new DelegateCommand<OA_UserFormDTO>(para => this.OpenEditor(para)));
            }
        }

        private ICommand _preStepCommand;
        public ICommand PreStepCommand
        {
            get
            {
                return this._preStepCommand ?? (this._preStepCommand = new DelegateCommand(() => this.PreStep()));
            }
        }

        private ICommand _disCardCommand;
        public ICommand DisCardCommand
        {
            get
            {
                return this._disCardCommand ?? (this._disCardCommand = new DelegateCommand(() => this.DisCard()));
            }
        }

        private ICommand _eventDataCommand;
        public ICommand EventDataCommand
        {
            get
            {
                return this._eventDataCommand ?? (this._eventDataCommand = new DelegateCommand(() => this.EventData()));
            }
        }

        private ICommand _printCommand;
        public ICommand PrintCommand
        {
            get
            {
                return this._printCommand ?? (this._printCommand = new DelegateCommand<OA_UserFormDTO>(para => this.Print(para)));
            }
        }

        private ObservableCollection<ISelectOption> _users;
        public ObservableCollection<ISelectOption> Users
        {
            get { return _users; }
            set
            {
                SetProperty(ref _users, value);
            }
        }

        private List<ISelectOption> _types;
        public List<ISelectOption> Types
        {
            get { return _types; }
            set
            {
                SetProperty(ref _types, value);
            }
        }

        protected IOperator _operator { get { return ContainerLocator.Current.Resolve<IOperator>(); } }

        protected override async Task GetData(object para)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    if (para is string id)
                    {
                        var result = await _dataProvider.GetData<OA_UserFormDTO>($"/OA_Manage/OA_UserForm/GetTheData", JsonConvert.SerializeObject(new { id = id }));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        Data = result.Data;
                    }
                    else
                    {
                        Data = new OA_UserFormDTO();
                    }
                    await GetUsers();
                    GetTypes();
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        protected override async Task<bool> SaveData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.GetData<AjaxResult>("/OA_Manage/OA_UserForm/SaveData", Data.ToJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Error(ex.Message);
                    return false;
                }
            }
        }       

        public override async Task<bool> ValidationAsync()
        {
            if (!string.IsNullOrEmpty(Data?.Error))
            {
                MessageBox.Info(Data.Error, windowIdentifier: Identifier);
                return false;
            }
            else if (!string.IsNullOrEmpty(Data.Id) && string.IsNullOrEmpty(Remark))
            {
                MessageBox.Info("请填写意见", windowIdentifier: Identifier);
                return false;
            }
            else
            {
                return await SaveData();
            }
        }

        private async Task GetUsers()
        {
            Users = await _userData.GetBase_User();
        }

        private void GetTypes()
        {
            _userData.ItemSource.TryGetValue(Data?.Type, out var types);

            Types = new List<ISelectOption>(types ?? new ObservableCollection<ISelectOption>());
            if (string.IsNullOrEmpty(this.Data.Unit) && Types.Count > 0)
            {
                this.Data.Unit = this.Types[0].Remark;
            }
        }

        private async void PreStep()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.GetData<List<OA_Step>>($"/OA_Manage/OA_UserForm/PreStep", Data.ToJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Data.Steps = result.Data;
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        private async void DisCard()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_UserForm/DisCardData", (new { id = Data.Id, remark = Data.Remarks }).ToJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    View.Close();
                    WindowBase.ShowMessageQueue(result.Msg, Identifier);
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        private async void EventData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var data = new
                    {
                        eventName = "MyEvent",
                        eventKey = Data.Id + Data.CurrentStepId,
                        Status = Status,
                        Remarks = Remark
                    };
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_UserForm/EventData", data.ToJson());
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    View.Close();
                    WindowBase.ShowMessageQueue(result.Msg, Identifier);
                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        private void Print(OA_UserFormDTO para)
        {
            try
            {
                PrintPreviewWindow previewWnd = new PrintPreviewWindow($"/AIStudio.Wpf.OA_Manage;component/Views/OA_UserFormEditFlowDocument.xaml", para);
                previewWnd.ShowDialog();
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
        }

        private async void OpenEditor(OA_UserFormDTO para)
        {
            OA_DefFormTreeEdit dialog = new OA_DefFormTreeEdit() { DataContext = new OA_DefFormTreeEditViewModel(para.WorkflowJSON) };
            var res = await WindowBase.ShowChildWindowAsync(dialog, "查看流程", Identifier);
        }
    }
}
