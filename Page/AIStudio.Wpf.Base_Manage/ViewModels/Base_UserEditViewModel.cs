using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
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

        private ObservableCollection<ISelectOption> _departments;
        public ObservableCollection<ISelectOption> Departments
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

       

        public Base_UserEditViewModel(Base_UserDTO data, string area, string identifier, string title = "编辑表单") : base(data, area, identifier, title)
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
                WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");

                var result = await _dataProvider.GetData<Base_UserDTO>($"/{Area}/{typeof(Base_UserDTO).Name.Replace("DTO", "")}/GetTheData", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;

                await GetRoles();
                await GetDepartment();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                WindowBase.HideWaiting(Identifier);
            }
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetAllRole();
            if (Data != null && Data.RoleIdList != null)
            {
                SelectedRoles = new ObservableCollection<ISelectOption>(Roles.Where(p => Data.RoleIdList.Contains(p.Value)));
            }
        }

        private async Task GetDepartment()
        {
            Departments = await _userData.GetAllTreeDepartment();
            if (Data != null && !string.IsNullOrEmpty(Data.DepartmentId))
            {
                SelectedDepartment = TreeHelper.GetTreeModel(Departments.Select(p => p as TreeModel), Data.DepartmentId);
            }
        }
    }
}
