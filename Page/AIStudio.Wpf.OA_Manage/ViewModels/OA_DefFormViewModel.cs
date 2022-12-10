using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormViewModel : BaseWindowViewModel<OA_DefFormDTO>
    {
        private ObservableCollection<ISelectOption> _roles;
        public ObservableCollection<ISelectOption> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(() => this.Edit()));
            }
        }

        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<OA_DefFormDTO>(para => this.Edit(para)));
            }
        }

        private ICommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                return this._copyCommand ?? (this._copyCommand = new CanExecuteDelegateCommand<OA_DefFormDTO>(para => this.Edit(para, "Edit")));
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new CanExecuteDelegateCommand<OA_DefFormDTO>(para => this.Start(para)));
            }
        }

        private ICommand _stopCommand;
        public ICommand StopCommand
        {
            get
            {
                return this._stopCommand ?? (this._stopCommand = new CanExecuteDelegateCommand<OA_DefFormDTO>(para => this.Stop(para)));
            }
        }

        protected IUserData _userData { get; }
        public OA_DefFormViewModel():base("OA_Manage", typeof(OA_DefFormEditViewModel), typeof(OA_DefFormEdit), "Name")
        {
            _userData = ContainerLocator.Current.Resolve<IUserData>();
                      
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetBase_Role();
        }

        protected override async void GetData(bool iswaiting = false)
        {
            
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                var result = await _dataProvider.GetData<List<OA_DefFormDTO>>($"/{Area}/{typeof(OA_DefFormDTO).Name.Replace("DTO", "")}/{GetDataList}", GetDataJson());
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<OA_DefFormDTO>(result.Data);

                    await GetRoles();
                    foreach (var item in Data)
                    {
                        if (item.ValueRoles != null)
                            item.Roles = Roles.Where(p => item.ValueRoles.Contains(p.Value)).ToList();
                    }                    
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

        //编辑情况下，不允许改变流程图
        protected async void Edit(OA_DefFormDTO para = null, string mode = "ReadOnly")
        {
            if (para == null)
            {
                mode = "Edit";
            }
            OA_DefFormEditViewModel viewmodel = new OA_DefFormEditViewModel(para, Area, mode == "Edit" ? "编辑表单":"复制表单");
            viewmodel.Mode = mode;
            OA_DefFormEdit dialog = new OA_DefFormEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (DialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
            if (res == DialogResult.OK)
            {
                try
                {
                    ShowWait();
                    if (mode == "Edit")
                    {
                        var json = viewmodel.GetFlowchartModel();
                        var data = JsonConvert.DeserializeObject<OA_Data>(json);
                        viewmodel.OAData.Nodes = data.Nodes;
                        viewmodel.OAData.Links = data.Links;
                        viewmodel.OAData.Groups = data.Groups;
                        viewmodel.Data.WorkflowJSON = JsonConvert.SerializeObject(viewmodel.OAData); 
                    }
                    viewmodel.Data.Value = viewmodel.SelectedRoles.Count == 0 ? null: "^" + string.Join("^" , viewmodel.SelectedRoles.Select(p => p.Value)) + "^";
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
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

        private async void Start(OA_DefFormDTO para)
        {            
            var sure = await MessageBoxDialog.Warning("确认启用吗?", "提示", Identifier);
            if (sure == DialogResult.OK)
            {
                try
                {
                    ShowWait();
 
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StartData", JsonConvert.SerializeObject(para));
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

        private async void Stop(OA_DefFormDTO para)
        {
            var sure = await MessageBoxDialog.Warning("确认停用吗?", "提示", Identifier);
            if (sure == DialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StopData", JsonConvert.SerializeObject(para));
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
    }
}
