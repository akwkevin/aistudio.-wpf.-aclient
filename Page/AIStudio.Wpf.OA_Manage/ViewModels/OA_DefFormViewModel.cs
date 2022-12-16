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
using Org.BouncyCastle.Crypto;

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

        private ICommand _stopCommand;
        public ICommand StopCommand
        {
            get
            {
                return this._stopCommand ?? (this._stopCommand = new CanExecuteDelegateCommand(() => this.Stop(null), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return this._startCommand ?? (this._startCommand = new CanExecuteDelegateCommand(() => this.Start(null), () => this.Data != null && this.Data.Count(p => p.IsChecked) > 0));
            }
        }

        private ICommand _startOneCommand;
        public ICommand StartOneCommand
        {
            get
            {
                return this._startOneCommand ?? (this._startOneCommand = new CanExecuteDelegateCommand<string>(para => this.Start(para)));
            }
        }

        private ICommand _stopOneCommand;
        public ICommand StopOneCommand
        {
            get
            {
                return this._stopOneCommand ?? (this._stopOneCommand = new CanExecuteDelegateCommand<string>(para => this.Stop(para)));
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

        protected override async Task GetData(bool iswaiting = false)
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
        protected override async void Edit(OA_DefFormDTO para = null)
        {
            OA_DefFormEditViewModel viewmodel = new OA_DefFormEditViewModel(para, Area,"编辑表单");
            OA_DefFormEdit dialog = new OA_DefFormEdit(viewmodel);
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

                    var json = viewmodel.GetFlowchartModel();
                    var data = JsonConvert.DeserializeObject<OA_Data>(json);
                    viewmodel.OAData.Nodes = data.Nodes;
                    viewmodel.OAData.Links = data.Links;
                    viewmodel.OAData.Groups = data.Groups;
                    viewmodel.Data.JSONId = string.Empty;
                    viewmodel.Data.WorkflowJSON = JsonConvert.SerializeObject(viewmodel.OAData);                     
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

        protected override async Task Delete(string id = null)
        {
            await base.Delete(id);
        }

        protected override void Print()
        {
            base.Print(Data);
        }

        protected override void Search(object para=null)
        {
            base.Search(para);
        }

        private async void Start(string id)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }
            var sure = await MessageBoxDialog.Show("确认启用吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                try
                {
                    ShowWait();
 
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StartData", JsonConvert.SerializeObject(ids));
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

        private async void Stop(string id)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrEmpty(id))
            {
                ids.AddRange(Data.Where(p => p.IsChecked).Select(p => p.Id));
            }
            else
            {
                ids.Add(id);
            }
            var sure = await MessageBoxDialog.Show("确认停用吗?", "提示", ControlStatus.Mid, Identifier);
            if (sure == DialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StopData", JsonConvert.SerializeObject(ids));
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
