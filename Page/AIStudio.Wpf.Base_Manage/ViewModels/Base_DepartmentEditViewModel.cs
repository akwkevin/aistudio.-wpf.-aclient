﻿using AIStudio.Core;
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

        public Base_DepartmentEditViewModel(Base_DepartmentTree dataTree, string area, string identifier, string title = "编辑表单") : base(null, area, identifier, title, autoInit:false)
        {
            if (dataTree == null)
            {
                InitData();
            }
            else
            {
                GetData(dataTree);
            }
        }

        protected override async void InitData()
        {
            Data = new Base_DepartmentDTO();
            await GetDepartment();
        }

        protected async void GetData(Base_DepartmentTree dataTree)
        {
            try
            {
                WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");

                var result = await _dataProvider.GetData<Base_DepartmentDTO>($"/Base_Manage/Base_Department/GetTheData", JsonConvert.SerializeObject(new { id = dataTree.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                Data = result.Data;
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
