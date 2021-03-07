using AIStudio.Core;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.IAppClient;
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

        private ObservableCollection<Base_LogDTO> _data;
        public ObservableCollection<Base_LogDTO> Data
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

        protected IDataProvider _dataProvider { get; }

        public Core.Models.Pagination Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 100 };

        private string FullName { get; set; }
        public Quartz_TaskLogViewModel(string fullname, string identifier, string title = "记录")
        {
            _dataProvider = ContainerLocator.Current.Resolve<IDataProvider>();

            Identifier = identifier;
            FullName = fullname;
            Title = title;
            GetData();            
        }


        protected async void GetData()
        {
            try
            {
                var control = Util.Controls.WindowBase.ShowWaiting(Util.Controls.WaitingType.Busy, Identifier);
                control.WaitInfo = "正在获取数据";

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", Pagination.PageIndex.ToString());
                data.Add("PageRows", Pagination.PageRows.ToString());
                data.Add("SortField", Pagination.SortField ?? "Id");
                data.Add("SortType", Pagination.SortType);
                data.Add("data", FullName);

                var result = await _dataProvider.GetData<List<Base_LogDTO>>($"/Base_Manage/Base_Log/GetLogList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                Pagination.Total = result.Total;
                Data = new ObservableCollection<Base_LogDTO>(result.ResponseItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Util.Controls.WindowBase.HideWaiting(Identifier);
            }
        }

        protected void Search(object para = null)
        {
            GetData();
        }
    }
}
