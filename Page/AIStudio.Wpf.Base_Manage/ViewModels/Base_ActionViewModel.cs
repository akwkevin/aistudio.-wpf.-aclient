using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

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
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Data = new ObservableCollection<IBaseTreeItemViewModel>(result.Data);
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
                else if (viewmodel.PermissionList.GroupBy(p => p.Value).Where(q => q.Count() > 1).Count() >= 1)
                {
                    MessageBox.Warning("权限值不能有重复值", windowIdentifier: Identifier);
                    return false;
                }
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();
                    viewmodel.Data.ParentId = viewmodel.SelectedParent?.Id;
                    viewmodel.Data.permissionList = new List<Base_ActionDTO>(viewmodel.PermissionList);
                    var result = await _dataProvider.GetData<AjaxResult>($"/Base_Manage/Base_Action/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
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

        protected override async void Delete(string id = null)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Select(p => p as Base_ActionTree).Where(p => p.IsChecked).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }

            await base.Delete(ids);
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
