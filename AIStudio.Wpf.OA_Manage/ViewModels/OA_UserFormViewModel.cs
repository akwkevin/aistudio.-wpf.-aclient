using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using AIStudio.Wpf.Service.AppClient;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.OA_Manage.ViewModels
{
    public class OA_UserFormViewModel : BaseWindowViewModel<OA_UserFormDTO>
    {
        private string _status = "processing";
        public string Status
        {
            get { return _status; }
            set
            {
                if (SetProperty(ref _status, value))
                {
                    GetData();
                }
            }
        }

        protected IOperator _operator { get; }

        public OA_UserFormViewModel() : base("OA_Manage", typeof(OA_UserFormEditViewModel), typeof(OA_UserFormEdit))
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
        }

        //无效参数，做个标记
        public OA_UserFormViewModel(string[] id) : base("OA_Manage", typeof(OA_UserFormEditViewModel), typeof(OA_UserFormEdit))
        {
            
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

                var userId = Status == "processing" ? _operator?.Property.Id : "";
                var applicantUserId = Status == "waiting" ? _operator?.Property.Id : "";
                var alreadyUserIds = Status == "finish" ? _operator?.Property.Id : "";
                var creatorId = Status == "created" ? _operator?.Property.Id : "";

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", Pagination.PageIndex.ToString());
                data.Add("PageRows", Pagination.PageRows.ToString());
                data.Add("SortField", Pagination.SortField ?? "Id");
                data.Add("SortType", Pagination.SortType);
                data.Add("keyword", KeyWord ?? "");
                data.Add("condition", ConditionItem != null ? ConditionItem.Tag.ToString() : "");
                data.Add("userId", userId);
                data.Add("applicantUserId", applicantUserId);
                data.Add("creatorId", creatorId);
                data.Add("alreadyUserIds", alreadyUserIds);
                var result = await _dataProvider.GetData<List<OA_UserFormDTO>>("/OA_Manage/OA_UserForm/GetDataList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<OA_UserFormDTO>(result.ResponseItem);
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

        public static async Task<BaseDialogResult> EditShow(OA_UserFormDTO para, string identifier)
        {
            var viewmodel = new OA_UserFormEditViewModel(para, "OA_Manage", "编辑表单");
            return await EditShow(viewmodel, identifier);
        }
        public static async Task<BaseDialogResult> EditShow(OA_UserFormEditViewModel viewmodel, string identifier)
        {
            var dialog = new OA_UserFormEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (string.IsNullOrEmpty(viewmodel.Remark))
                {
                    MessageBoxHelper.ShowHit("请填写意见", identifier);
                    return false;
                }
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync(dialog, identifier);
            return res;
        }

        protected override async void Edit(OA_UserFormDTO para = null)
        {
            var viewmodel = new OA_UserFormEditViewModel(para, "OA_Manage", "编辑表单");
            var res = await EditShow(viewmodel, Identifier);
            if (res == BaseDialogResult.Other1 || res == BaseDialogResult.Other2)
            {
                try
                {
                    ShowWait();

                    if (res == BaseDialogResult.Other1)
                    {
                        var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_UserForm/DisCardData?id={viewmodel.Data.Id}");
                        if (!result.IsOK)
                        {
                            throw new Exception(result.ErrorMessage);
                        }
                    }
                    else if (res == BaseDialogResult.Other2)
                    {
                        var myEvent = new
                        {
                            UserId = _operator?.Property?.Id,
                            UserName = _operator?.Property?.UserName,
                            Status = viewmodel.Status,
                            Remarks = viewmodel.Remark
                        };
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("eventName", "MyEvent");
                        data.Add("eventKey", viewmodel.Data.Id + viewmodel.Data.CurrentStepId);
                        data.Add("eventDataJson", JsonConvert.SerializeObject(myEvent));
                        var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_UserForm/EventData", data);
                        if (!result.IsOK)
                        {
                            throw new Exception(result.ErrorMessage);
                        }
                        WindowBase.ShowMessageQueue(result.ResponseItem?.Msg, Identifier);
                    }
                    await Task.Delay(100);
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

        public void EditById(object[] id)
        {
            Edit(new OA_UserFormDTO() { Id = id[0] as string });
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected override void Search(object para = null)
        {
            base.Search(para);
        }
    }
}
