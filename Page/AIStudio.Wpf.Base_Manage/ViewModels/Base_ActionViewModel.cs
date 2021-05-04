using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.BasePage.Views;
using AIStudio.Wpf.EFCore.DTOModels;
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
    public class Base_ActionViewModel : BaseWindowViewModel<Base_ActionDTO>
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
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<Base_ActionTree>(para => this.Edit(para)));
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

        public Base_ActionViewModel() : base("Base_Manage", typeof(Base_ActionEditViewModel), typeof(Base_ActionEdit), "GetMenuTreeList")
        {
            Pagination = new Core.Models.Pagination() { PageRows = Int32.MaxValue };          
        }

        public override void Initialize()
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

                var result = await _dataProvider.GetData<List<Base_ActionTree>>($"/Base_Manage/Base_Action/GetMenuTreeList");
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Data = new ObservableCollection<IBaseTreeItemViewModel>(result.ResponseItem);
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

        protected async void Edit(Base_ActionTree paraTree = null)
        {
            var viewmodel = new Base_ActionEditViewModel(paraTree, Area, Identifier);

            var dialog = new Base_ActionEdit(viewmodel);
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
                    viewmodel.Data.ParentId = viewmodel.SelectedParent?.ParentId;
                    viewmodel.Data.permissionListJson = JsonConvert.SerializeObject(viewmodel.PermissionList);
                    var result = await _dataProvider.GetData<AjaxResult>($"/Base_Manage/Base_Action/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
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

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para = null)
        {
            base.Search(para);
        }
    }
}
