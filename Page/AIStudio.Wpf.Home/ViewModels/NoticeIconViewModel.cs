using AIStudio.Core;
using AIStudio.Core.ExCommand;
using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.Wpf.OA_Manage.ViewModels;
using AIStudio.Wpf.OA_Manage.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AIStudio.Wpf.Home.ViewModels
{
    public class NoticeIconViewModel : BaseWaitingViewModel
    {
        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (SetProperty(ref _selectedIndex, value))
                {
                    GetData();
                }
            }
        }      

        private ObservableCollection<GroupData> _userMessage;
        public ObservableCollection<GroupData> UserMessage
        {
            get { return _userMessage; }
            set
            {
                SetProperty(ref _userMessage, value);
            }
        }

        private ObservableCollection<OA_UserFormDTO> _userForm;
        public ObservableCollection<OA_UserFormDTO> UserForm
        {
            get { return _userForm; }
            set
            {
                SetProperty(ref _userForm, value);
            }
        }

        private int _totalCount;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set
            {
                SetProperty(ref _totalCount, value);
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return this._refreshCommand ?? (this._refreshCommand = new DelegateCommand(() => this.GetData()));
            }
        }

        private ICommand _moreCommand;
        public ICommand MoreCommand
        {
            get
            {
                return this._moreCommand ?? (this._moreCommand = new DelegateCommand<string>(para => this.More(para)));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new DelegateCommand<object>(para => this.Edit(para)));
            }
        }

        public Core.Models.Pagination Notice_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };

        public Core.Models.Pagination UserMail_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };

        public Core.Models.Pagination UserMessage_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };

        public Core.Models.Pagination UserForm_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };
       
        public string Identifier { get; set; } = LocalSetting.RootWindow;

        protected IOperator _operator { get => ContainerLocator.Current.Resolve<IOperator>(); }
        protected IDataProvider _dataProvider { get => ContainerLocator.Current.Resolve<IDataProvider>(); }
        protected IUserData _userData { get => ContainerLocator.Current.Resolve<IUserData>(); }
        protected IEventAggregator _aggregator { get => ContainerLocator.Current.Resolve<IEventAggregator>(); }

        public NoticeIconViewModel(string identifier)
        {
            Identifier = identifier;
        }

        private async void GetData()
        {
            switch (SelectedIndex)
            {
                case 0: await GetUserForm(); break;
            }
        }


        private async Task GetUserForm()
        {
            try
            {
                ShowWait();

                var data = new
                {
                    PageIndex = UserMessage_Pagination.PageIndex,
                    PageRows = UserMessage_Pagination.PageRows,
                    SortField = UserMessage_Pagination.SortField,
                    SortType = UserMessage_Pagination.SortType,
                    Search = new
                    {
                        userId = _operator?.Property?.Id,
                    }
                };

                var result = await _dataProvider.GetData<List<OA_UserFormDTO>>($"/OA_Manage/OA_UserForm/GetPageHistoryDataList", JsonConvert.SerializeObject(data));
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    UserForm_Pagination.Total = result.Total;
                    UserForm = new ObservableCollection<OA_UserFormDTO>(result.Data);
                    TotalCount = Notice_Pagination.Total + UserMail_Pagination.Total + UserMessage_Pagination.Total + UserForm_Pagination.Total;
                }
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

        private Dictionary<string, string> Dictionary = new Dictionary<string, string>()
        {
            { "OA_UserFormDTO", typeof(OA_UserFormView).FullName },
        };

        private void More(string para)
        {
            _aggregator.GetEvent<MenuExcuteEvent>().Publish(new Tuple<string, string>(Identifier, Dictionary[para]));
        }

        private async void Edit(object para)
        {
            var exCommandParameter = para as ExCommandParameter;
            var obj = (exCommandParameter.Sender as ListBox).SelectedItem;

            if (obj is OA_UserFormDTO)
            {
                //(new OA_UserFormViewModel() { Identifier = Identifier }).Edit(new OA_UserFormDTO() { Id = (obj as OA_UserFormDTO).Id });
            }
        }
    }

    public class PushMessageData
    {
        public string[] Clearcache { get; set; }

        public List<GroupData> UserMessage { get; set; }

        public int NoticeCount { get; set; }
        public int UserMessageCount { get; set; }
        public int UserMailCount { get; set; }
        public int UserFormCount { get; set; }
    }

    public class GroupData
    {
        public int Total { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string Avatar { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string UserIds { get; set; }
        public string UserNames { get; set; }
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
