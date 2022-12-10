﻿using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AIStudio.Wpf.Controls;

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

        public OA_UserFormViewModel() : base("OA_Manage", typeof(OA_UserFormEditViewModel), typeof(OA_UserFormEdit), "DefFormName")
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
        }

        //无效参数，做个标记
        public OA_UserFormViewModel(string[] id) : base("OA_Manage", typeof(OA_UserFormEditViewModel), typeof(OA_UserFormEdit), "DefFormName")
        {

        }

        protected override string GetDataJson()
        {
            var searchKeyValues = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(Condition) && !string.IsNullOrEmpty(KeyWord))
            {
                searchKeyValues.Add(Condition, KeyWord);
            }

            var userId = Status == "processing" ? _operator?.Property.Id : "";
            var applicantUserId = Status == "waiting" ? _operator?.Property.Id : "";
            var alreadyUserIds = Status == "finish" ? _operator?.Property.Id : "";
            var creatorId = Status == "created" ? _operator?.Property.Id : "";

            var data = new
            {
                PageIndex = Pagination.PageIndex,
                PageRows = Pagination.PageRows,
                SortField = Pagination.SortField,
                SortType = Pagination.SortType,
                SearchKeyValues = searchKeyValues,
                Search = new
                {
                    userId = userId,
                    applicantUserId = applicantUserId,
                    creatorId = creatorId,
                    alreadyUserIds = alreadyUserIds,
                }
            };

            return JsonConvert.SerializeObject(data);
        }

        public static async Task<DialogResult> EditShow(OA_UserFormDTO para, string identifier)
        {
            var viewmodel = new OA_UserFormEditViewModel(para, "OA_Manage", "编辑表单");
            return await EditShow(viewmodel, identifier);
        }
        public static async Task<DialogResult> EditShow(OA_UserFormEditViewModel viewmodel, string identifier)
        {
            var dialog = new OA_UserFormEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (string.IsNullOrEmpty(viewmodel.Remark))
                {
                    Controls.MessageBox.Info("请填写意见", windowIdentifier: identifier);
                    return false;
                }
                else
                    return true;
            });
            var res = (DialogResult)await WindowBase.ShowDialogAsync2(dialog, identifier);
            return res;
        }

        protected override async void Edit(OA_UserFormDTO para = null)
        {
            var viewmodel = new OA_UserFormEditViewModel(para, "OA_Manage", "编辑表单");
            var res = await EditShow(viewmodel, Identifier);
            if (res == DialogResult.Other1 || res == DialogResult.Other2)
            {
                try
                {
                    ShowWait();

                    if (res == DialogResult.Other1)
                    {
                        var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_UserForm/DisCardData", JsonConvert.SerializeObject(new { id = viewmodel.Data.Id }));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                    }
                    else if (res == DialogResult.Other2)
                    {
                        var data = new
                        {
                            eventName = "MyEvent",
                            eventKey = viewmodel.Data.Id + viewmodel.Data.CurrentStepId,
                            Status = viewmodel.Status,
                            Remarks = viewmodel.Remark
                        };
                        var result = await _dataProvider.GetData<AjaxResult>($"/OA_Manage/OA_UserForm/EventData", JsonConvert.SerializeObject(data));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                        WindowBase.ShowMessageQueue(result.Msg, Identifier);
                    }
                    await Task.Delay(100);
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

        public void EditById(object[] id)
        {
            Edit(new OA_UserFormDTO() { Id = id[0] as string });
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
