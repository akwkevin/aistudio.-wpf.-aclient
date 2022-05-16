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
    public class Base_UserLogViewModel : BaseWindowViewModel<Base_UserLogDTO>
    {
        private string _logContent;
        public string LogContent
        {
            get { return _logContent; }
            set
            {
                if (_logContent != value)
                {
                    _logContent = value;
                    RaisePropertyChanged("LogContent");
                }
            }
        }

        private string _level;
        public string Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    RaisePropertyChanged("Level");
                }
            }
        }

        private string _logType;
        public string LogType
        {
            get { return _logType; }
            set
            {
                if (_logType != value)
                {
                    _logType = value;
                    RaisePropertyChanged("LogType");
                }
            }
        }

        private string _opUserName;
        public string OpUserName
        {
            get { return _opUserName; }
            set
            {
                if (_opUserName != value)
                {
                    _opUserName = value;
                    RaisePropertyChanged("OpUserName");
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

        private List<SelectOption> _logTypeList;
        public List<SelectOption> LogTypeList
        {
            get { return _logTypeList; }
            set
            {
                if (_logTypeList != value)
                {
                    _logTypeList = value;
                    RaisePropertyChanged("LogTypeList");
                }
            }
        }

        private List<SelectOption> _loglevelList;
        public List<SelectOption> LoglevelList
        {
            get { return _loglevelList; }
            set
            {
                if (_loglevelList != value)
                {
                    _loglevelList = value;
                    RaisePropertyChanged("LoglevelList");
                }
            }
        }

        public Base_UserLogViewModel():base("Base_Manage", typeof(BaseEditViewModel<Base_UserLogDTO>), typeof(Base_UserlogEdit))
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
            InitData();
        }

        private async void InitData()
        {
            await GetLogTypeList();
            GetData();
        }

        private async Task GetLogTypeList()
        {
            var result = await _dataProvider.GetData<List<SelectOption>>($"/Base_Manage/Base_UserLog/GetLogTypeList");
            if (!result.Success)
            {
                throw new Exception(result.Msg);
            }
            else
            {
                LogTypeList = result.Data;
                LogTypeList.Insert(0, new SelectOption() { value = "", text = "" });
                LogType = "";
            }
        }

        protected override async void GetData(bool iswaiting = false)
        {
            try
            {
                if (iswaiting == false)
                {
                    ShowWait();
                }               

                var data = new
                {
                    PageIndex = Pagination.PageIndex,
                    PageRows = Pagination.PageRows,
                    SortField = Pagination.SortField,
                    SortType = Pagination.SortType,
                    Search = new
                    {
                        logContent = LogContent,
                        logType = LogType,
                        opUserName = OpUserName,
                        startTime = StartTime.HasValue? StartTime.Value.ToString("yyyy-MM-dd hh:mm:ss") : "",
                        endTime = EndTime.HasValue ? EndTime.Value.ToString("yyyy-MM-dd hh:mm:ss") : "",
                    }
                };

                var result = await _dataProvider.GetData<List<Base_UserLogDTO>>($"/Base_Manage/Base_UserLog/GetLogList", JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<Base_UserLogDTO>(result.Data);
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

        protected override void Search(object para=null)
        {
            base.Search(para);
        }
    }
}
