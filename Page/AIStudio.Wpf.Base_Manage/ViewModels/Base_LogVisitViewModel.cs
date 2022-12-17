using AIStudio.Core;
using AIStudio.Wpf.Base_Manage.Views;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_LogVisitViewModel : BaseListViewModel<Base_LogVisitDTO>
    {
        private string _creatorName;
        public string CreatorName
        {
            get { return _creatorName; }
            set
            {
                if (_creatorName != value)
                {
                    _creatorName = value;
                    RaisePropertyChanged("CreatorName");
                }
            }
        }

        private DateTime? _startTime;
        public DateTime? StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    RaisePropertyChanged("StartTime");
                }
            }
        }

        private DateTime? _endTime;
        public DateTime? EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    RaisePropertyChanged("EndTime");
                }
            }
        }       

        public Base_LogVisitViewModel() 
        {
            Area = "Base_Manage";
            Condition = "Message";
        }    

        protected override string GetDataJson()
        {
            var searchKeyValues = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(Condition) && !string.IsNullOrEmpty(KeyWord))
            {
                searchKeyValues.Add(Condition, KeyWord);
            }          
            if (!string.IsNullOrEmpty(CreatorName))
            {
                searchKeyValues.Add("CreatorName", CreatorName);
            }

            var data = new
            {
                PageIndex = Pagination.PageIndex,
                PageRows = Pagination.PageRows,
                SortField = Pagination.SortField,
                SortType = Pagination.SortType,
                SearchKeyValues = searchKeyValues,
                Search = new
                {                   
                    StartTime = StartTime.HasValue ? StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
                    EndTime = EndTime.HasValue ? EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
                }
            };

            return JsonConvert.SerializeObject(data);
        }

    }
}
