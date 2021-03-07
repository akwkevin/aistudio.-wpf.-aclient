using AIStudio.Core;
using AIStudio.Core.ExCommand;
using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.D_Manage.ViewModels;
using AIStudio.Wpf.OA_Manage.ViewModels;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.IAppClient;
using AIStudio.Wpf.Service.ITempService;
using AIStudio.Wpf.Service.IWebSocketClient;
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

namespace AIStudio.Wpf.HomePage.ViewModels
{
    class NoticeIconViewModel : BaseWaitingViewModel
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

        private ObservableCollection<D_UserMailDTO> _userMail;
        public ObservableCollection<D_UserMailDTO> UserMail
        {
            get { return _userMail; }
            set
            {
                SetProperty(ref _userMail, value);
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


        public Core.Models.Pagination UserMail_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };

        public Core.Models.Pagination UserMessage_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };

        public Core.Models.Pagination UserForm_Pagination { get; set; } = new Core.Models.Pagination() { PageRows = 5 };
       
        public string Identifier { get; set; } = LocalSetting.RootWindow;

        protected IOperator _operator { get => ContainerLocator.Current.Resolve<IOperator>(); }
        protected IDataProvider _dataProvider { get => ContainerLocator.Current.Resolve<IDataProvider>(); }
        protected IWSocketClient _wSocketClient { get => ContainerLocator.Current.Resolve<IWSocketClient>(); }
        protected IUserData _userData { get => ContainerLocator.Current.Resolve<IUserData>(); }
        protected IEventAggregator _aggregator { get => ContainerLocator.Current.Resolve<IEventAggregator>(); }

        protected MainViewModel _mainViewmodel { get; }

        public NoticeIconViewModel(MainViewModel mainViewmodel, string identifier)
        {
            _mainViewmodel = mainViewmodel;
            Identifier = identifier;

            _wSocketClient.MessageReceived -= _wSocketClient_MessageReceived;
            _wSocketClient.MessageReceived += _wSocketClient_MessageReceived;
        }

        private void _wSocketClient_MessageReceived(WSMessageType type, string message)
        {
            if (type == WSMessageType.PushType)
            {
                var resmsg = JsonConvert.DeserializeObject<PushMessageData>(message);
                UserMail_Pagination.Total = resmsg.UserMailCount;
                UserMessage_Pagination.Total = resmsg.UserMessageCount;
                UserForm_Pagination.Total = resmsg.UserFormCount;
                TotalCount = UserMail_Pagination.Total + UserMessage_Pagination.Total + UserForm_Pagination.Total;
                var clearcache = resmsg.Clearcache;

                if (clearcache.Contains("Base_User"))
                {
                    _userData.ClearAllUser();
                }

                if (clearcache.Contains("Base_Role"))
                {
                    _userData.ClearAllRole();
                }
            }
        }


        private async void GetData()
        {
            switch (SelectedIndex)
            {
                case 0: await GetUserMail(); break;
                case 1: await GetUserMessage(); break;
                case 2: await GetUserForm(); break;
            }
        }
        private async Task GetUserMail()
        {
            try
            {
                ShowWait();

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", UserMail_Pagination.PageIndex.ToString());
                data.Add("PageRows", UserMail_Pagination.PageRows.ToString());
                data.Add("SortField", UserMail_Pagination.SortField ?? "Id");
                data.Add("SortType", UserMail_Pagination.SortType);
                data.Add("userId", _operator?.Property?.Id);
                data.Add("markflag", true.ToString());

                var result = await _dataProvider.GetData<List<D_UserMailDTO>>($"/D_Manage/D_UserMail/GetHistoryDataList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    UserMail_Pagination.Total = result.Total;
                    UserMail = new ObservableCollection<D_UserMailDTO>(result.ResponseItem);
                    TotalCount = UserMail_Pagination.Total + UserMessage_Pagination.Total + UserForm_Pagination.Total;
                }
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

        private async Task GetUserMessage()
        {
            try
            {
                ShowWait();

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("userId", _operator?.Property?.Id);
                data.Add("markflag", true.ToString());

                var result = await _dataProvider.GetData<List<GroupData>>($"/D_Manage/D_UserMessage/GetHistoryGroupDataList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    UserMessage_Pagination.Total = result.ResponseItem.Sum(p => p.Total);
                    UserMessage = new ObservableCollection<GroupData>(result.ResponseItem);
                    TotalCount = UserMail_Pagination.Total + UserMessage_Pagination.Total + UserForm_Pagination.Total;
                }
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

        private async Task GetUserForm()
        {
            try
            {
                ShowWait();

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("PageIndex", UserForm_Pagination.PageIndex.ToString());
                data.Add("PageRows", UserForm_Pagination.PageRows.ToString());
                data.Add("SortField", UserForm_Pagination.SortField ?? "Id");
                data.Add("SortType", UserForm_Pagination.SortType);
                data.Add("userId", _operator?.Property?.Id);

                var result = await _dataProvider.GetData<List<OA_UserFormDTO>>($"/OA_Manage/OA_UserForm/GetHistoryDataList", data);
                if (!result.IsOK)
                {
                    throw new Exception(result.ErrorMessage);
                }
                else
                {
                    UserForm_Pagination.Total = result.Total;
                    UserForm = new ObservableCollection<OA_UserFormDTO>(result.ResponseItem);
                    TotalCount = UserMail_Pagination.Total + UserMessage_Pagination.Total + UserForm_Pagination.Total;
                }
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

        private Dictionary<string, string> Dictionary = new Dictionary<string, string>()
        {
            { "D_UserMailDTO", "/D_Manage/D_UserMail/Index" },
            { "D_UserMessageDTO", "/D_Manage/D_UserMessage/List" },
            { "OA_UserFormDTO", "/D_Manage/OA_UserForm/List" },
        };


        private void More(string para)
        {
            _mainViewmodel.SelectedMenuItem = new AToolItem() { Code = Dictionary[para], Type = 1 };
        }

        private async void Edit(object para)
        {
            var exCommandParameter = para as ExCommandParameter;
            var obj = (exCommandParameter.Sender as ListBox).SelectedItem;

            if (obj is D_UserMailDTO)
            {
                await D_UserMailViewModel.EditShow(new D_UserMailDTO() { Id = (obj as D_UserMailDTO).Id }, Identifier);
            }
            else if (obj is OA_UserFormDTO)
            {
                await OA_UserFormViewModel.EditShow(new OA_UserFormDTO() { Id = (obj as OA_UserFormDTO).Id }, Identifier);
            }
            if (obj is GroupData)
            {
                GroupData message = obj as GroupData;
                D_UserMessageViewModel.EditShow(new string[] { message.CreatorId, message.CreatorName, message.Avatar, message.GroupId, message.GroupName, message.UserIds, message.UserNames });
            }
        }
    }

    public class PushMessageData
    {
        public string[] Clearcache { get; set; }

        public List<GroupData> UserMessage { get; set; }
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
