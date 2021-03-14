using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business.DTOModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    public class Base_LogViewModel : BaseWindowViewModel<Base_UserLogDTO>
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

        public Base_LogViewModel():base("Base_Manage", typeof(BaseEditViewModel<Base_UserLogDTO>), typeof(BaseDialog))
        {
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            InitData();
        }

        private async void InitData()
        {
            await GetLogTypeList();
            await GetLoglevelList();
            GetData();
        }

        private async Task GetLogTypeList()
        {
            var result = await _dataProvider.GetData<List<SelectOption>>($"/Base_Manage/Base_Log/GetLogTypeList");
            if (!result.IsOK)
            {
                throw new Exception(result.ErrorMessage);
            }
            else
            {
                LogTypeList = result.ResponseItem;
                LogType = "系统任务执行";
            }
        }

        private async Task GetLoglevelList()
        {
            var result = await _dataProvider.GetData<List<SelectOption>>($"/Base_Manage/Base_Log/GetLoglevelList");
            if (!result.IsOK)
            {
                throw new Exception(result.ErrorMessage);
            }
            else
            {
                LoglevelList = result.ResponseItem;
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

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", Pagination.PageIndex.ToString());
                data.Add("PageRows", Pagination.PageRows.ToString());
                data.Add("SortField", Pagination.SortField ?? "Id");
                data.Add("SortType", Pagination.SortType);
                data.Add("logContent", LogContent ?? "");
                data.Add("level", Level ?? "");
                data.Add("logType", LogType ?? "");
                data.Add("opUserName", OpUserName ?? "");
                if (StartTime != null)
                {
                    data.Add("startTime", StartTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
                }
                if (EndTime != null)
                {
                    data.Add("endTime", EndTime.Value.ToString("yyyy-MM-dd hh:mm:ss"));
                }
                var result = await _dataProvider.GetData<List<Base_UserLogDTO>>($"/Base_Manage/Base_Log/GetLogList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<Base_UserLogDTO>(result.ResponseItem);
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
