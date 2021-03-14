using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_DepartmentViewModel : BaseWindowViewModel<Base_DepartmentDTO>
    {
        private ObservableCollection<IBaseTreeItemViewModel> _data;
        public new ObservableCollection<IBaseTreeItemViewModel> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    RaisePropertyChanged("Data");
                }
            }
        }

        private ObservableCollection<Base_UserDTO> _data2;
        public ObservableCollection<Base_UserDTO> Data2
        {
            get { return _data2; }
            set
            {
                if (_data2 != value)
                {
                    _data2 = value;
                    RaisePropertyChanged("Data2");
                }
            }
        }


        private ICommand _addCommand;
        public new ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new CanExecuteDelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<Base_DepartmentTree>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public new ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _subAddCommand;
        public ICommand SubAddCommand
        {
            get
            {
                return this._subAddCommand ?? (this._subAddCommand = new CanExecuteDelegateCommand<Base_DepartmentTree>(para => this.Edit(para, true)));
            }
        }

        private ICommand _selectedCommand;
        public ICommand SelectedCommand
        {
            get
            {
                return this._selectedCommand ?? (this._selectedCommand = new CanExecuteDelegateCommand<Base_DepartmentTree>(para => this.Selected(para)));
            }
        }

        public Base_DepartmentViewModel() : base("Base_Manage", typeof(Base_DepartmentEditViewModel), typeof(Base_DepartmentEdit))
        {
            Pagination = new Core.Models.Pagination() { PageRows = Int32.MaxValue };
        }

        protected override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var result = await _dataProvider.GetData<List<Base_DepartmentTree>>($"/Base_Manage/Base_Department/GetTreeDataList");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Data = new ObservableCollection<IBaseTreeItemViewModel>(result.ResponseItem);
                    Data2 = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected async void Edit(Base_DepartmentTree paraTree = null, bool isSubAdd = false)
        {
            var viewmodel = new Base_DepartmentEditViewModel(isSubAdd ? null : paraTree, Area, Identifier);
            if (isSubAdd)
            {
                viewmodel.SelectedDepartment = TreeHelper.GetTreeModel(viewmodel.Departments, paraTree.Id);
            }
            var dialog = new Base_DepartmentEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    viewmodel.Data.ParentId = viewmodel.SelectedDepartment?.Id;
                    var result = await _dataProvider.GetData<AjaxResult>($"/Base_Manage/Base_Department/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.IsOK)
                    {
                        throw new Exception(result.ErrorMessage);
                    }
                    GetData(true);
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
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected override void Search(object para = null)
        {
            base.Search(para);
        }

        private async void Selected(Base_DepartmentTree para)
        {
            try
            {
                var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
                control.WaitInfo = "正在获取数据";

                var result = await _dataProvider.GetData<List<Base_UserDTO>>($"/Base_Manage/Base_User/GetDataListByDepartment", JsonConvert.SerializeObject(new { id = para.Id }));
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Data2 = new ObservableCollection<Base_UserDTO>(result.ResponseItem);
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
    }
}
