using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormEditViewModel : BaseEditViewModel<OA_DefFormDTO>
    {
        private string _flowchartModel;
        public string FlowchartModel
        {
            get { return _flowchartModel; }
            set
            {
                SetProperty(ref _flowchartModel, value);
            }
        }


        private Func<string> _getFlowchartModel;
        public Func<string> GetFlowchartModel
        {
            get
            {
                return _getFlowchartModel;
            }
            set
            {
                SetProperty(ref _getFlowchartModel, value);
            }
        }

        public OA_Data OAData { get; set; }

        private string _mode = "Edit";
        public string Mode
        {
            get { return _mode; }
            set
            {
                SetProperty(ref _mode, value);
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

        private ObservableCollection<ISelectOption> _roles;
        public ObservableCollection<ISelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }

        private ObservableCollection<ISelectOption> _selectedRoles = new ObservableCollection<ISelectOption>();
        public ObservableCollection<ISelectOption> SelectedRoles
        {
            get { return _selectedRoles; }
            set
            {
                SetProperty(ref _selectedRoles, value);
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

        public OA_DefFormEditViewModel(OA_DefFormDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
        {
        }

		protected override async void InitData()
		{
			Data = new OA_DefFormDTO();
            OAData = new OA_Data();
            FlowchartModel = "{}";
            GetTypes();
            await GetRoles();
            await GetUsers();
        }

        protected override async void GetData(OA_DefFormDTO para)
        {
            try
            {
                ShowWait();

                var result = await _dataProvider.GetData<OA_DefFormDTO>($"/OA_Manage/OA_DefForm/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
                GetTypes();
                await GetRoles();
                await GetUsers();

                OAData = Newtonsoft.Json.JsonConvert.DeserializeObject<OA_Data>(Data.WorkflowJSON);
                FlowchartModel = Data.WorkflowJSON;
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                HideWait();
            }
        }   
        private void GetTypes()
        {
            _userData.ItemSource.TryGetValue("流程分类", out var types);

            Types = new List<ISelectOption>(types ?? new ObservableCollection<ISelectOption>());
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetBase_Role();
            if (Data != null && Data.ValueRoles != null)
            {
                SelectedRoles = new ObservableCollection<ISelectOption>(Roles.Where(p => Data.ValueRoles.Contains(p.Value)));
            }
        }

        private async Task GetUsers()
        {
            Users = await _userData.GetBase_User();
        }
    }
}
