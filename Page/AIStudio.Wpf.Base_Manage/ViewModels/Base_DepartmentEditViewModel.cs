using AIStudio.Core;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using AIStudio.Wpf.Controls;
using System.Linq;
using AIStudio.Wpf.GridControls.ViewModel;
using AIStudio.Wpf.BasePage.Models;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DepartmentEditViewModel : BaseEditViewModel<Base_DepartmentDTO>
    {
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

        public Base_DepartmentEditViewModel()
        {
        }

        protected override async Task GetData(object option)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    await base.GetData(option);
                    await GetDepartment();                  
                }
                catch (Exception ex)
                {
                    MessageBox.Error(ex.Message);
                }
            }
        }

        protected override async Task<bool> SaveData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    Data.ParentId = SelectedDepartment?.Id;                  
                    return await base.SaveData();
                }
                catch (Exception ex)
                {
                    MessageBox.Error(ex.Message);
                    return false;
                }
            }
        }

        private async Task GetDepartment()
        {
            Departments = await _userData.GetBase_DepartmentTree();
            if (Data != null && !string.IsNullOrEmpty(Data.ParentId))
            {
                SelectedDepartment = TreeHelper.GetTreeModel(Departments.Select(p => p as TreeModel), Data.ParentId);
            }
        }
    }

  
}
