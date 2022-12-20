using AIStudio.Core;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Entity.DTOModels;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIStudio.Wpf.Quartz_Manage.ViewModels
{
    public class Quartz_TaskLogViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private ObservableCollection<Base_LogSystemDTO> _data;
        public ObservableCollection<Base_LogSystemDTO> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        private ICommand _currentIndexChangedComamnd;
        public ICommand CurrentIndexChangedComamnd
        {
            get
            {
                return this._currentIndexChangedComamnd ?? (this._currentIndexChangedComamnd = new DelegateCommand<object>(para => this.Search(para)));
            }
        }

        public string Identifier { get; set; } = LocalSetting.RootWindow;

        protected IDataProvider _dataProvider { get { return ContainerLocator.Current.Resolve<IDataProvider>(); } }

        public Core.Models.Pagination Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 100 };

        private string FullName { get; set; }
        public Quartz_TaskLogViewModel(string fullname, string identifier)
        {
            Identifier = identifier;
            FullName = fullname;
            GetData();            
        }


        protected async void GetData()
        {
            using (var waitfor = WaitFor.GetWaitFor(this.GetHashCode(), Identifier))
            {
                try
                {
                    var data = new
                    {
                        PageIndex = Pagination.PageIndex,
                        PageRows = Pagination.PageRows,
                        SortField = Pagination.SortField,
                        SortType = Pagination.SortType,
                        SearchKeyValues = new Dictionary<string, object>()
                        {
                            {"LogType", UserLogType.系统任务.ToString() },
                            {"Name", FullName}
                        }
                    };

                    var result = await _dataProvider.GetData<List<Base_LogSystemDTO>>($"/Base_Manage/Base_LogSystem/GetDataList", JsonConvert.SerializeObject(data));
                    if (!result.Success)
                    {
                        throw new Exception(result.Msg);
                    }
                    Pagination.Total = result.Total;
                    Data = new ObservableCollection<Base_LogSystemDTO>(result.Data);

                }
                catch (Exception ex)
                {
                    Controls.MessageBox.Error(ex.Message);
                }
            }
        }

        protected void Search(object para = null)
        {
            GetData();
        }
    }
}
