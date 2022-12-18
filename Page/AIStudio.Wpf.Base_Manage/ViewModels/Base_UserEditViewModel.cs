using AIStudio.Core;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.GridControls.ViewModel;
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

        protected override async Task GetData(object para)
        {
            try
            {
                ShowWait();

                if (para is string id)
                {
                    var result = await _dataProvider.GetData<Base_UserDTO>($"/{Area}/{typeof(Base_UserDTO).Name.Replace("DTO", "")}/GetTheData", JsonConvert.SerializeObject(new { id = id }));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Data = result.Data;
                }
                else
                {
                    Data = new Base_UserDTO();
                }

                await GetRoles();
                await GetDepartment();
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

        protected override async Task<bool> SaveData()
        {
            try
            {
                ShowWait();
                Data.RoleIdList = SelectedRoles.Select(p => p.Value).ToList();
                Data.DepartmentId = SelectedDepartment?.Id;
                var result = await _dataProvider.GetData<AjaxResult>("/Base_Manage/Base_User/SaveData", Data.ToJson());
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
            finally
            {
                HideWait();
            }
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetBase_Role();
            if (Data != null && Data.RoleIdList != null)
            {
                SelectedRoles = new ObservableCollection<ISelectOption>(Roles.Where(p => Data.RoleIdList.Contains(p.Value)));
            }
        }

        private async Task GetDepartment()
        {
            Departments = await _userData.GetBase_DepartmentTree();
            if (Data != null && !string.IsNullOrEmpty(Data.DepartmentId))
            {
                SelectedDepartment = TreeHelper.GetTreeModel(Departments.Select(p => p as TreeModel), Data.DepartmentId);
            }
        }
    }
}
