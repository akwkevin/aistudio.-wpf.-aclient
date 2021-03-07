using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.OA_Manage.Models;
using AIStudio.Wpf.OA_Manage.Views;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.ITempService;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Util.Controls;
using Util.Controls.DialogBox;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_DefFormViewModel : BaseWindowViewModel<OA_DefFormDTO>
    {
        private List<Base_RoleEasy> _roles;
        public List<Base_RoleEasy> Roles
        {
            get { return _roles; }
            set
            {
                SetProperty(ref _roles, value);
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
        public OA_DefFormViewModel():base("OA_Manage", typeof(OA_DefFormEditViewModel), typeof(OA_DefFormEdit))
        {
            _userData = ContainerLocator.Current.Resolve<IUserData>();
                      
        }

        protected override void Initialize()
        {
            base.Initialize();
            GetData();
        }

        private async Task GetRoles()
        {
            Roles = await _userData.GetAllRole();
        }

        protected override async void GetData(bool iswaiting = false)
        {
            
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", Pagination.PageIndex.ToString());
                data.Add("PageRows", Pagination.PageRows.ToString());
                data.Add("SortField", Pagination.SortField ?? "Id");
                data.Add("SortType", Pagination.SortType);
                data.Add("keyword", KeyWord ?? "");
                data.Add("condition", ConditionItem != null ? ConditionItem.Tag.ToString() : "");

                var result = await _dataProvider.GetData<List<OA_DefFormDTO>>($"/{Area}/{typeof(OA_DefFormDTO).Name.Replace("DTO", "")}/{GetDataList}", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<OA_DefFormDTO>(result.ResponseItem);

                    await GetRoles();
                    foreach (var item in Data)
                    {
                        if (item.ValueRoles != null)
                            item.Roles = Roles.Where(p => item.ValueRoles.Contains(p.Id)).ToList();
                    }                    
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
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, Identifier);
            if (res == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();
                    if (mode == "Edit")
                    {
                        viewmodel.Data.Id = string.Empty;
                        FlowChartHelper.FlowChartToG6(viewmodel.FlowchartModel, viewmodel.OAData);
                        viewmodel.Data.WorkflowJSON = JsonConvert.SerializeObject(viewmodel.OAData); 
                    }
                    viewmodel.Data.Value = viewmodel.SelectedRoles.Count == 0 ? null: "^" + string.Join("^" , viewmodel.SelectedRoles.Select(p => p.Id)) + "^";
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
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

        protected override void Search(object para=null)
        {
            base.Search(para);
        }

        private async void Start(OA_DefFormDTO para)
        {            
            var sure = await Msg.Warning("确认启用吗?", BoxType.Metro, Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();
 
                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StartData", JsonConvert.SerializeObject(para));
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

        private async void Stop(OA_DefFormDTO para)
        {
            var sure = await Msg.Warning("确认停用吗?", BoxType.Metro, Identifier);
            if (sure == BaseDialogResult.OK)
            {
                try
                {
                    ShowWait();

                    var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_DefForm/StopData", JsonConvert.SerializeObject(para));
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
    }
}
