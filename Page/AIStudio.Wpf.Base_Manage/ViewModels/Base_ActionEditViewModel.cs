using AIStudio.Core.Models;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.GridControls.ViewModel;
using System.Linq;
using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_ActionEditViewModel : BaseEditViewModel<Base_ActionDTO>
    {
        private ObservableCollection<Base_ActionTree> _parentIdTreeData;
        public ObservableCollection<Base_ActionTree> ParentIdTreeData
        {
            get { return _parentIdTreeData; }
            set
            {
                SetProperty(ref _parentIdTreeData, value);
            }
        }

        private Base_ActionTree _selectedParent;
        public Base_ActionTree SelectedParent
        {
            get { return _selectedParent; }
            set
            {
                SetProperty(ref _selectedParent, value);
            }
        }

        private ObservableCollection<Base_ActionDTO> _permissionList = new ObservableCollection<Base_ActionDTO>();
        public ObservableCollection<Base_ActionDTO> PermissionList
        {
            get { return _permissionList; }
            set
            {
                SetProperty(ref _permissionList, value);
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(() => this.Add()));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new DelegateCommand<Base_ActionDTO>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new DelegateCommand<Base_ActionDTO>(para => this.Delete(para)));
            }
        }

        public Base_ActionEditViewModel() 
        {

        }

        protected override async Task GetData(object option)
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {              
                try
                {
                    await base.GetData(option);
                    await GetParentIdTreeData();                  
                    await GetPermissionList();                   
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
                    Data.ParentId = SelectedParent?.Id;
                    Data.permissionList = new List<Base_ActionDTO>(PermissionList);
                    return await base.SaveData();
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
            if (PermissionList.GroupBy(p => p.Value).Where(q => q.Count() > 1).Count() >= 1)
            {
                MessageBox.Error("权限值不能有重复值", windowIdentifier: Identifier);
                return false;
            }
            else
            { 
                return await base.ValidationAsync();
            }
        } 

        private async Task GetParentIdTreeData()
        {
            var result = await _dataProvider.GetData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetMenuTreeList");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                ParentIdTreeData = new ObservableCollection<Base_ActionTree>(result.Data);
                SelectedParent = GetTreeItem(ParentIdTreeData, Data.ParentId);
            }
        }

        private async Task GetPermissionList()
        {
            if (!string.IsNullOrEmpty(Data?.Id))
            {
                var result = await _dataProvider.GetData<List<Base_ActionDTO>>($"/Base_Manage/Base_Action/GetPermissionList", JsonConvert.SerializeObject(new { parentId = Data.Id }));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    PermissionList = new ObservableCollection<Base_ActionDTO>(result.Data);
                }
            }
        }

        private Base_ActionTree GetTreeItem(ObservableCollection<Base_ActionTree> parentIdTreeData, string id)
        {
            foreach (var data in parentIdTreeData)
            {
                if (data.Id == id)
                {
                    return data;
                }
                else
                {
                    if (data.Children != null)
                    {
                        var child = GetTreeItem(data.Children, id);
                        if (child != null)
                            return child;
                    }
                }
            }

            return null;
        }

        private void Add()
        {
            PermissionList.Add(new Base_ActionDTO() { Name = "权限名", Value = $"权限值{PermissionList.Count + 1}", ParentId = Data?.Id, Type = 2, IsReadOnly = false });
        }

        private void Edit(Base_ActionDTO para)
        {
            para.IsReadOnly = !para.IsReadOnly;
        }

        private void Delete(Base_ActionDTO para)
        {
            PermissionList.Remove(para);
        }

    }




}
