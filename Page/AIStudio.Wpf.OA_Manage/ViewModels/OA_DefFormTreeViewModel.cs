using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormTreeViewModel : BaseWindowViewModel<OA_DefFormDTO>
    {
        private ObservableCollection<OA_DefFormTree> _data;
        public new ObservableCollection<OA_DefFormTree> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<OA_DefFormTree>(para => this.Edit(para)));
            }
        }

        private ICommand _openEditorCommand;
        public ICommand OpenEditorCommand
        {
            get
            {
                return this._openEditorCommand ?? (this._openEditorCommand = new CanExecuteDelegateCommand<OA_DefFormTree>(para => this.OpenEditor(para)));
            }
        }

        protected IUserData _userData { get; }
        public OA_DefFormTreeViewModel() : base("OA_Manage", typeof(OA_DefFormTreeViewModel), null,"")
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

                var result = await _dataProvider.GetData<List<OA_DefFormTree>>("/OA_Manage/OA_DefForm/GetTreeDataList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Data = new ObservableCollection<OA_DefFormTree>(result.Data);
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

        private async void Edit(OA_DefFormTree para)
        {
            var viewmodel = new OA_UserFormEditViewModel(null, Area, Identifier, para.title, para.type, para.key, para.jsonId, para.jsonVersion, para.json);
            var dialog = new OA_UserFormEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (DialogResult)await WindowBase.ShowChildWindowAsync(dialog, "编辑表单", Identifier);
            if (res == DialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>("/OA_Manage/OA_UserForm/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Controls.MessageBox.Info("操作成功", windowIdentifier: Identifier);
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

        private async void OpenEditor(OA_DefFormTree para)
        {
            OA_DefFormTreeEditViewModel viewmodel = new OA_DefFormTreeEditViewModel(para.json);
            OA_DefFormTreeEdit dialog = new OA_DefFormTreeEdit(viewmodel);
            var res = await WindowBase.ShowChildWindowAsync(dialog, "编辑表单", Identifier);
        }
    }
}
