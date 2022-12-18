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
            try
            {
                ShowWait();

                if (option is string id)
                {
                    var result = await _dataProvider.GetData<Base_DepartmentDTO>($"/Base_Manage/Base_Department/GetTheData", JsonConvert.SerializeObject(new { id = id }));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Data = result.Data;
                    await GetDepartment();
                }
                else
                {
                    Data = new Base_DepartmentDTO();
                    await GetDepartment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Error(ex.Message);
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

                Data.ParentId = SelectedDepartment?.Id;
                var result = await _dataProvider.GetData<AjaxResult>($"/Base_Manage/Base_Department/SaveData", Data.ToJson());
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
