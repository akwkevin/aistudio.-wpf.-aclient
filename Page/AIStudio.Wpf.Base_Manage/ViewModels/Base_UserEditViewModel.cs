using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.EFCore.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_UserEditViewModel : BaseEditViewModel<Base_UserDTO>
    {
        private List<SelectOption> _roles;
        public List<SelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }

        private ObservableCollection<SelectOption> _selectedRoles = new ObservableCollection<SelectOption>();
        public ObservableCollection<SelectOption> SelectedRoles
        {
            get { return _selectedRoles; }
            set
            {
                SetProperty(ref _selectedRoles, value);
            }
        }

        private List<TreeModel> _departments;
        public List<TreeModel> Departments
        {
            get { return _departments; }
            set
            {
                SetProperty(ref _departments, value);
            }
        }

        private TreeModel _selectedDepartment;
        public TreeModel SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                SetProperty(ref _selectedDepartment, value);
            }
        }

       

        public Base_UserEditViewModel(Base_UserDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title, true)
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

        protected override async void InitData()
        {
            Data = new Base_UserDTO();
            await GetRoles();
            await GetDepartment();
        }

        protected override async void GetData(Base_UserDTO para)
        {
            try
            {
                var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
                control.WaitInfo = "正在获取数据";

                var result = await _dataProvider.GetData<Base_UserDTO>($"/{Area}/{typeof(Base_UserDTO).Name.Replace("DTO", "")}/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data = result.ResponseItem;

                await GetRoles();
                await GetDepartment();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Util.Controls.WindowBase.HideWaiting(Identifier);
            }
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetAllRole();
            if (Data != null && Data.RoleIdList != null)
            {
                SelectedRoles = new ObservableCollection<SelectOption>(Roles.Where(p => Data.RoleIdList.Contains(p.value)));
            }
        }

        private async Task GetDepartment()
        {
            Departments = (await _userData.GetAllDepartment()).DeepClone<List<TreeModel>>();
            if (Data != null && !string.IsNullOrEmpty(Data.DepartmentId))
            {
                SelectedDepartment = TreeHelper.GetTreeModel(Departments, Data.DepartmentId);
            }
        }
    }
}
