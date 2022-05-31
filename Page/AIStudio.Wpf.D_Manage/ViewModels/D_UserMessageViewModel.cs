using AIStudio.Core;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.D_Manage.Views;
using AIStudio.Wpf.Entity.DTOModels;
using AIStudio.LocalConfiguration;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMessageViewModel : BaseWindowViewModel<D_UserGroupDTO>
    {
        private ObservableCollection<D_OnlineUserDTO> _userDatas;
        public ObservableCollection<D_OnlineUserDTO> UserDatas
        {
            get { return _userDatas; }
            set
            {
                if (_userDatas != value)
                {
                    _userDatas = value;
                    RaisePropertyChanged("UserDatas");
                }
            }
        }

        private D_OnlineUserDTO _selectedUser;
        public D_OnlineUserDTO SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (SetProperty(ref _selectedUser, value))
                {
                    D_UserMessageEditViewModel.SelectedUser = SelectedUser;
                }
            }
        }

        private D_UserMessageEditViewModel _d_UserMessageEditViewModel;
        public D_UserMessageEditViewModel D_UserMessageEditViewModel
        {
            get { return _d_UserMessageEditViewModel; }
            set
            {
                SetProperty(ref _d_UserMessageEditViewModel, value);
            }
        } 

        private ICommand _searchCommand;
        public new ICommand SearchCommand
        {
            get
            {
                return this._searchCommand ?? (this._searchCommand = new CanExecuteDelegateCommand<object>(para => this.Search(para)));
            }
        }

        private ICommand _addCommand;
        public new ICommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new CanExecuteDelegateCommand(() => this.Edit()));
            }
        }
        private ICommand _editCommand;
        public new ICommand EditCommand
        {
            get
            {
                return this._editCommand ?? (this._editCommand = new CanExecuteDelegateCommand<D_OnlineUserDTO>(para => this.Edit(para)));
            }
        }

        protected IOperator _operator { get; }
        protected IWSocketClient _wSocketClient { get; }
        protected IUserConfig _userConfig { get; }

        protected ListCollectionView _view;

        public D_UserMessageViewModel() : base("D_Manage", typeof(D_UserGroupEditViewModel), typeof(D_UserGroupEdit))
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
            _wSocketClient = ContainerLocator.Current.Resolve<IWSocketClient>();
            _wSocketClient.MessageReceived += _wSocketClient_MessageReceived;
            _userConfig = ContainerLocator.Current.Resolve<IUserConfig>();

            D_UserMessageEditViewModel = new D_UserMessageEditViewModel(null, "D_Manage", Identifier);
        }

        public D_UserMessageViewModel(string[] id)//无效参数，做个标记
        {

        }

        private void _wSocketClient_MessageReceived(WSMessageType arg1, object arg2)
        {
            if (arg1 == WSMessageType.MessageType)
            {
                D_UserMessageDTO resmsg = JsonConvert.DeserializeObject<D_UserMessageDTO>(arg2 as string);

                if ((this.SelectedUser.IsGroup == false && string.IsNullOrEmpty(resmsg.GroupId)
                    && (resmsg.UserIds.IndexOf("^" + _operator.Property?.Id + "^") >= 0
                    || resmsg.UserIds.IndexOf("^" + this.SelectedUser.UserId + "^") >= 0))
                    || (this.SelectedUser.IsGroup = true && this.SelectedUser.UserId == resmsg.GroupId))
                {
                    if (resmsg.CreatorId != _operator.Property.Id)
                    {
                        D_OnlineUserDTO tempdata = null;
                        if (string.IsNullOrEmpty(resmsg.GroupId))
                        {
                            tempdata = UserDatas.FirstOrDefault(d => d.UserId == resmsg.CreatorId);
                        }
                        else
                        {
                            tempdata = UserDatas.FirstOrDefault(d => d.UserId == resmsg.GroupId);
                        }
                        if (tempdata != null)
                        {
                            tempdata.LastDateTime = resmsg.CreateTime;
                            tempdata.LastMessage = resmsg.Text;

                            _userConfig.WriteConfig(this, UserDatas);

                            Application.Current.Dispatcher.Invoke((Action)delegate ()
                            {
                                if (_view != null)
                                {
                                    _view.Refresh();
                                }
                            });
                        }
                    }
                }
            }
            else if (arg1 == WSMessageType.OnlineUser)
            {
                var datas = JsonConvert.DeserializeObject<List<D_OnlineUserDTO>>(arg2 as string);
                if (UserDatas != null)
                {
                    UserDatas.ForEach((item) =>
                    {
                        if (!item.IsGroup)
                        {
                            var tempdata = datas.FirstOrDefault((d) => d.UserId == item.UserId);
                            if (tempdata != null)
                            {
                                item.Online = true;
                            }
                            else
                            {
                                item.Online = false;
                            }
                        }
                    });
                }
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

                var result = await _dataProvider.GetData<List<D_OnlineUserDTO>>($"/D_Manage/D_UserMessage/GetUserList");
                if (!result.Success)
                {
                    throw new Exception(result.Msg);
                }
                else
                {
                    UserDatas = new ObservableCollection<D_OnlineUserDTO>(result.Data);
                    var localdatas = _userConfig.ReadConfig<List<D_OnlineUserDTO>>(this);

                    UserDatas.ForEach((item) =>
                    {
                        var tempdata = localdatas.FirstOrDefault((d) => d.UserId == item.UserId);
                        if (tempdata != null)
                        {
                            item.LastDateTime = tempdata.LastDateTime;
                            item.LastMessage = tempdata.LastMessage;
                        }
                    });

                    _view = (ListCollectionView)CollectionViewSource.GetDefaultView(UserDatas);
                    _view.CustomSort = new UserDataSorter();
                    _view.Refresh();

                    foreach (var item in _view)
                    {
                        SelectedUser = item as D_OnlineUserDTO;
                        break;
                    }
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

        protected async void Edit(D_OnlineUserDTO para = null)
        {
            if (para != null && !para.IsGroup)
            {
                return;
            }
            D_UserGroupEditViewModel viewmodel = null;
            if (para != null)
            {
                viewmodel = new D_UserGroupEditViewModel(new D_UserGroupDTO() { Id = para.UserId }, Area, Identifier);
            }
            else
            {
                viewmodel = new D_UserGroupEditViewModel(null, Area, Identifier, Identifier);
            }
            var dialog = new D_UserGroupEdit(viewmodel);
            dialog.ValidationAction = (() =>
            {
                if (!string.IsNullOrEmpty(viewmodel.Data.Error))
                    return false;
                else
                    return true;
            });
            var res = (BaseDialogResult)await WindowBase.ShowDialogAsync2(dialog, Identifier);
            if (res == BaseDialogResult.OK || res == BaseDialogResult.Other1)
            {
                try
                {
                    ShowWait();

                    if (res == BaseDialogResult.OK)//修改
                    {
                        viewmodel.Data.UserIds = "^" + string.Join("^", viewmodel.SelectedUsers.Select(p => p.Value)) + "^";
                        viewmodel.Data.UserNames = "^" + string.Join("^", viewmodel.SelectedUsers.Select(p => p.Text)) + "^";
                        viewmodel.Data.Avatar = viewmodel.Data.Avatar ?? "/Images/group.jpg";
                        var result = await _dataProvider.GetData<AjaxResult>($"/D_Manage/D_UserMessage/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                        if (!result.Success)
                        {
                            throw new Exception(result.Msg);
                        }
                    }
                    else if (res == BaseDialogResult.Other1)
                    {
                        if (viewmodel.Disabled == false)//解散
                        {
                            var result = await _dataProvider.GetData<AjaxResult>($"/D_Manage/D_UserMessage/DeleteData", JsonConvert.SerializeObject(new string[] { viewmodel.Data.Id }));
                            if (!result.Success)
                            {
                                throw new Exception(result.Msg);
                            }
                        }
                        else//退出
                        {
                            viewmodel.SelectedUsers.Remove(viewmodel.SelectedUsers.Where(p => p.Value == _operator?.Property?.Id).FirstOrDefault());
                            viewmodel.Data.UserIds = "^" + string.Join("^", viewmodel.SelectedUsers.Select(p => p.Value)) + "^";
                            viewmodel.Data.UserNames = "^" + string.Join("^", viewmodel.SelectedUsers.Select(p => p.Text)) + "^";

                            var result = await _dataProvider.GetData<AjaxResult>($"/D_Manage/D_UserMessage/SaveData", JsonConvert.SerializeObject(viewmodel.Data));
                            if (!result.Success)
                            {
                                throw new Exception(result.Msg);
                            }
                        }
                    }
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

        public static void EditShow(object[] id)
        {
            string CreatorId = id[0] as string;
            string CreatorName = id[1] as string;
            string Avatar = id[2] as string;
            string GroupId = id[3] as string;
            string GroupName = id[4] as string;
            string UserIds = id[5] as string;
            string UserNames = id[6] as string;

            D_OnlineUserDTO userDTO = new D_OnlineUserDTO();

            if (string.IsNullOrEmpty(GroupId))
            {
                userDTO.UserId = CreatorId;
                userDTO.UserName = CreatorName;
            }
            else
            {
                userDTO.IsGroup = true;
                userDTO.UserId = GroupId;
                userDTO.UserName = GroupName;
            }
            userDTO.Avatar = Avatar;
            userDTO.UserIds = UserIds;
            userDTO.UserNames = UserNames;

            EditShow(userDTO);
        }

        public static void EditShow(D_OnlineUserDTO para)
        {
            D_UserMessageEditViewModel viewmodel = new D_UserMessageEditViewModel(para, "D_Manage", $"和[{para.UserName}]的聊天");

            var dialog = new D_UserMessageEdit(viewmodel);
            dialog.Show();
        }

        protected override void Delete(string id = null)
        {
            base.Delete(id);
        }

        protected new void Search(object para)
        {
            SelectedUser = UserDatas?.FirstOrDefault(p => p.UserName == para as string);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _wSocketClient.MessageReceived -= _wSocketClient_MessageReceived;
            }
        }

        //customized sorter
        class UserDataSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                D_OnlineUserDTO a = (D_OnlineUserDTO)x;
                D_OnlineUserDTO b = (D_OnlineUserDTO)y;
  
                if (a.Online && b.Online)
                {
                    if (a.LastDateTime.HasValue && b.LastDateTime.HasValue)
                    {
                        return a.LastDateTime > b.LastDateTime ? -1 : 1;
                    }
                    else if (a.LastDateTime.HasValue)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (a.Online)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
