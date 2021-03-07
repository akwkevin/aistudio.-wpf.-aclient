using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Util.Controls;

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

        private ObservableCollection<Base_ActionDTO> _permissionList;
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

        public Base_ActionEditViewModel(Base_ActionTree dataTree, string area, string identifier, string title = "编辑表单") : base(null, area, identifier, title)
        {
            if (dataTree == null)
            {
                Data = new Base_ActionDTO();
            }
            else
            {
                GetData(dataTree);
            }
        }

        protected async void GetData(Base_ActionTree dataTree)
        {
            try
            {
                var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
                control.WaitInfo = "正在获取数据";

                var result = await _dataProvider.GetData<Base_ActionDTO>($"/Base_Manage/Base_Action/GetTheData?id={dataTree.Id}");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data = result.ResponseItem;

                await GetParentIdTreeData();
                await GetPermissionList();
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

        private async Task GetParentIdTreeData()
        {
            var result = await _dataProvider.GetData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetMenuTreeList");
            if (!result.IsOK)
            {
                throw new Exception(result.ErrorMessage);
            }
            else
            {
                ParentIdTreeData = new ObservableCollection<Base_ActionTree>(result.ResponseItem);
                SelectedParent = GetTreeItem(ParentIdTreeData, Data.ParentId);
            }
        }

        private async Task GetPermissionList()
        {
            var result = await _dataProvider.GetData<List<Base_ActionDTO>>($"/Base_Manage/Base_Action/GetPermissionList?parentId={Data.Id}");
            if (!result.IsOK)
            {
                throw new Exception(result.ErrorMessage);
            }
            else
            {
                PermissionList = new ObservableCollection<Base_ActionDTO>(result.ResponseItem);
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
                        return GetTreeItem(data.Children, id);
                    }
                }
            }

            return null;
        }

        private void Add()
        {
            PermissionList.Add(new Base_ActionDTO() { Name = "权限名", Value = "权限值", ParentId = Data?.Id, Type = 2, IsReadOnly = false });
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
