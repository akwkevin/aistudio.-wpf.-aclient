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
                return this._preStepCommand ?? (this._preStepCommand = new DelegateCommand<OA_UserFormDTO>(para => this.PreStep(para)));
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

        private List<OA_DefTypeDTO> _types;
        public List<OA_DefTypeDTO> Types
        {
            get { return _types; }
            set
            {
                SetProperty(ref _types, value);
            }
        }

        protected IOperator _operator { get; }

        public OA_UserFormEditViewModel(OA_UserFormDTO data, string area, string identifier, string title = "编辑表单") : this(data, area, identifier, title, "", "", "", 0, "") { }

        public OA_UserFormEditViewModel(OA_UserFormDTO data, string area, string identifier, string title, string type, string key, string jsonId, int jsonVersion, string json) : base(data, area, identifier, title)
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
            if (Data == null)
            {
                Data = new OA_UserFormDTO() { Type = type, DefFormId = key, DefFormName = title, DefFormJsonId = jsonId, DefFormJsonVersion = jsonVersion, WorkflowJSON = json, ApplicantUserId = _operator?.Property?.Id };
                InitData();
            }
            else
            {
                GetData(Data);
            }
        }

        protected override async void InitData()
        {

            await GetUsers();
            await GetTypes();
        }

        protected override async void GetData(OA_UserFormDTO para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<OA_UserFormDTO>($"/OA_Manage/OA_UserForm/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
                await GetUsers();
                await GetTypes();
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

        private async Task GetUsers()
        {
            Users = await _userData.GetAllUser();
        }

        private async Task GetTypes()
        {
            var data = new
            {
                Search = new
                {
                    condition = "Type",
                    keyword = Data?.Type
                }
            };
            var result = await _dataProvider.GetData<List<OA_DefTypeDTO>>($"/OA_Manage/OA_DefType/GetDataList", JsonConvert.SerializeObject(data));
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            Types = result.Data;
            if (string.IsNullOrEmpty(this.Data.Unit) && Types.Count > 0)
            {
                this.Data.Unit = this.Types[0].Unit;
            }
        }

        private async void PreStep(OA_UserFormDTO para)
        {
            try
            {
                ShowWait();
                var result = await _dataProvider.GetData<List<OAStep>>($"/OA_Manage/OA_UserForm/PreStep", JsonConvert.SerializeObject(para));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data.Steps = result.Data;
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

        private void Print(OA_UserFormDTO para)
        {
            try
            {
                PrintPreviewWindow previewWnd = new PrintPreviewWindow($"/AIStudio.Wpf.OA_Manage;component/Views/OA_UserFormEditFlowDocument.xaml", para);
                previewWnd.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void OpenEditor(OA_UserFormDTO para)
        {
            OA_DefFormTreeEditViewModel viewmodel = new OA_DefFormTreeEditViewModel(para.WorkflowJSON);
            OA_DefFormTreeEdit dialog = new OA_DefFormTreeEdit(viewmodel);
            var res = await WindowBase.ShowDialogAsync2(dialog, Identifier);
        }
    }
}
