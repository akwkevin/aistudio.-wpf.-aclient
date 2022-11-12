using AIStudio.Core;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefTypeViewModel : BaseWindowViewModel<OA_DefTypeDTO>
    {
        private ObservableCollection<IBaseTreeItemViewModel> _data;
        public new ObservableCollection<IBaseTreeItemViewModel> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
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
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<OA_DefTypeTree>(para => this.Edit(para)));
            }
        }

        private ICommand _deleteCommand;
        public new ICommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new CanExecuteDelegateCommand(() => this.Delete(), () => this.Data != null && this.Data.Count(p => p.IsChecked == true) > 0));
            }
        }

        public OA_DefTypeViewModel():base("OA_Manage", typeof(OA_DefTypeEditViewModel), typeof(OA_DefTypeEdit), "Name")
        {
	
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var result = await _dataProvider.GetData<List<OA_DefTypeTree>>($"/OA_Manage/OA_DefType/GetTreeDataList", GetDataJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<IBaseTreeItemViewModel>(result.Data);
                }
            }
            catch (Exception ex)
            {
                Controls.MessageBox.Error(ex.Message);
            }
            finally
            {
                if (iswaiting == false)
                {
                    HideWait();
                }
            }
        }

        protected async void Edit(OA_DefTypeTree paraTree = null)
        {
            OA_DefTypeEditViewModel viewmodel = null;
            if (paraTree != null)
            {
                viewmodel = new OA_DefTypeEditViewModel(new OA_DefTypeDTO() { Id = paraTree.RealId }, Area, Identifier);
            }
            else
            {
                viewmodel = new OA_DefTypeEditViewModel(null, Area, Identifier);
            }

            var dialog = new OA_DefTypeEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();
                  
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefType/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    GetData(true);
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
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
