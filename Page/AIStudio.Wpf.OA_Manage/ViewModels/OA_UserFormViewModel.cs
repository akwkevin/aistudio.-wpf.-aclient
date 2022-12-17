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
    public class OA_UserFormViewModel : BaseListViewModel<OA_UserFormDTO, OA_UserFormEdit>
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

        protected IOperator _operator { get { return ContainerLocator.Current.Resolve<IOperator>(); } }

        public OA_UserFormViewModel()
        {
            Area = "OA_Manage";
            Condition = "DefFormName";
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
                    UserId = userId,
                    ApplicantUserId = applicantUserId,
                    CreatorId = creatorId,
                    AlreadyUserIds = alreadyUserIds,
                }
            };

            return JsonConvert.SerializeObject(data);
        }

        protected override BaseEditViewModel2<OA_UserFormDTO> GetEditViewModel()
        {
            return new OA_UserFormEditViewModel();
        }       

        protected override async Task Delete(string id = null)
        {
            await base.Delete(id);
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
