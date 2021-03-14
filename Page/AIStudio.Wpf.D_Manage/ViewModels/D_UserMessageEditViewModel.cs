using AIStudio.Core;
using AIStudio.Core.ExCommand;
using AIStudio.Wpf.BasePage.Controls;
using AIStudio.Wpf.BasePage.ViewModels;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Business.DTOModels;
using AIStudio.Wpf.Service.AppClient;
using AIStudio.Wpf.Service.IWebSocketClient;
using Newtonsoft.Json;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Util.Controls.Data;

namespace AIStudio.Wpf.D_Manage.ViewModels
{
    public class D_UserMessageEditViewModel : BaseEditViewModel<D_UserGroupDTO>
    {     

        private ICommand _sendComamnd;
        public ICommand SendComamnd
        {
            get
            {
                return this._sendComamnd ?? (this._sendComamnd = new CanExecuteDelegateCommand<object>(para => this.Send(para)));
            }
        }

        private ICommand _historySearchComamnd;
        public ICommand HistorySearchComamnd
        {
            get
            {
                return this._historySearchComamnd ?? (this._historySearchComamnd = new CanExecuteDelegateCommand<object>(para => this.HistorySearch(para)));
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
                    SelectedUserChanged();
                }
            }
        }

        private ObservableCollection<D_UserMessageDTO> _data;
        public new ObservableCollection<D_UserMessageDTO> Data
        {
            get { return _data; }
            set
            {
                SetProperty(ref _data, value);
            }
        }

        protected IOperator _operator { get; }
        protected IWSocketClient _wSocketClient { get; }

        public D_UserMessageEditViewModel(D_OnlineUserDTO data, string area, string identifier, string title = "编辑表单") : base(null, area, identifier, title, true)
        {
            _operator = ContainerLocator.Current.Resolve<IOperator>();
            _wSocketClient = ContainerLocator.Current.Resolve<IWSocketClient>();
            _wSocketClient.MessageReceived += _wSocketClient_MessageReceived;

            SelectedUser = data;           
        }

        private void _wSocketClient_MessageReceived(WSMessageType arg1, object arg2)
        {
            if (SelectedUser == null) return;

            if (arg1 == WSMessageType.MessageType)
            {
                D_UserMessageDTO resmsg = JsonConvert.DeserializeObject<D_UserMessageDTO>(arg2 as string);

                if ((this.SelectedUser.IsGroup == false && string.IsNullOrEmpty(resmsg.GroupId)
                    && (resmsg.CreatorId == this.SelectedUser.UserId || resmsg.CreatorId == _operator.Property?.Id))
                    || (this.SelectedUser.IsGroup = true && this.SelectedUser.UserId == resmsg.GroupId))
                {
                    resmsg.Role = _operator.Property?.Id == resmsg.CreatorId ? "Sender" : "Receiver";
                    Application.Current.Dispatcher.Invoke((Action)delegate ()
                    {
                        var endmsg = Data?.LastOrDefault();
                        if (endmsg != null)
                        {
                            if ((endmsg.CreateTime - resmsg.CreateTime).TotalMilliseconds > 60000)
                            {
                                resmsg.ShowTime = true;
                            }
                            else
                            {
                                resmsg.ShowTime = false;
                            }
                        }
                        else
                        {
                            resmsg.ShowTime = true;
                        }
                        Data.Add(resmsg);
                    });


                    if (resmsg.CreatorId != _operator.Property.Id)
                    {
                        if ((resmsg.ReadingMarks ?? "").IndexOf("^" + _operator.Property.Id + "^") == -1)
                        {
                            resmsg.ReadingMarks = resmsg.ReadingMarks ?? "^" + _operator.Property.Id + "^";

                            //设为已读
                            MessageResult send = new MessageResult();
                            send.Success = true;
                            send.MessageType = WSMessageType.ReadMessageType;
                            send.Data = resmsg;

                            _wSocketClient.SendMessage(JsonConvert.SerializeObject(send));
                        }                      
                    }
                }
            }
        }    

        private async void Send(object para)
        {
            ExCommandParameter parameter = para as ExCommandParameter;
            if (parameter != null)
            {
                var content = (parameter.EventArgs as ChatSendEventArgs).Content;
                if (content.Text != null && SelectedUser != null)
                {
                    D_UserMessageDTO sendMessage = new D_UserMessageDTO();
                    if (content.Type == (int)ChatMessageType.String)
                    {
                        sendMessage.Text = content.Text;

                    }
                    else if (content.Type == (int)ChatMessageType.Image || content.Type == (int)ChatMessageType.Video || content.Type == (int)ChatMessageType.Audio || content.Type == (int)ChatMessageType.Upload)
                    {
                        var result = await _dataProvider.UploadFileByForm(content.Text);
                        if (result.status == "done")
                        {
                            sendMessage.Text = result.url;
                        }
                    }

                    sendMessage.CreatorName = _operator.Property?.UserName;
                    sendMessage.CreatorId = _operator.Property?.Id;
                    if (SelectedUser.IsGroup)
                    {
                        sendMessage.GroupId = SelectedUser.UserId;
                        sendMessage.GroupName = SelectedUser.UserName;
                        sendMessage.UserNames = SelectedUser.UserNames;
                        sendMessage.UserIds = SelectedUser.UserIds;
                    }
                    else
                    {
                        sendMessage.UserNames = "^" + SelectedUser.UserName + "^";
                        sendMessage.UserIds = "^" + SelectedUser.UserId + "^";
                    }
                    sendMessage.Avatar = _operator.Property?.Avatar;

                    sendMessage.Type = content.Type;
                    sendMessage.Role = "Sender";

                    MessageResult send = new MessageResult();
                    send.Success = true;
                    send.MessageType = WSMessageType.MessageType;
                    send.Data = sendMessage;

                    _wSocketClient.SendMessage(JsonConvert.SerializeObject(send));
                }
            }
        }

        private async void HistorySearch(object para)
        {
            ExCommandParameter parameter = para as ExCommandParameter;
            if (parameter != null)
            {
                var start = (parameter.EventArgs as HistorySearchEventArgs).StartTime;
                var end = (parameter.EventArgs as HistorySearchEventArgs).EndTime;
                if (SelectedUser != null)
                {
                    try
                    {
                        ShowWait();
                        var data = new
                        {
                            Search = new
                            {
                                creatorId = _operator.Property?.Id,
                                userId = this.SelectedUser?.UserId,
                                isGroup = this.SelectedUser?.IsGroup,
                                start = start.ToString("yyyy - MM - dd HH:mm: ss"),
                                end = end.ToString("yyyy - MM - dd HH:mm: ss")
                            }
                        };

                        var result = await _dataProvider.GetData<List<D_UserMessageDTO>>($"/D_Manage/D_UserMessage/GetHistoryDataList", JsonConvert.SerializeObject(data));
                        if (!result.IsOK)
                        {
                            throw new Exception(result.ErrorMessage);
                        }
                        else
                        {
                            Data = new ObservableCollection<D_UserMessageDTO>(result.ResponseItem);
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
            }
        }

        private async void GetUnReadData()
        {
            try
            {
                ShowWait();

                if (this.SelectedUser != null)
                {
                    var data = new
                    {
                        Search = new
                        {
                            userId = _operator.Property?.Id,
                            creatorId = this.SelectedUser?.UserId,
                            markflag = true,
                            isGroup = this.SelectedUser?.IsGroup
                        }
                    };

                    var result = await _dataProvider.GetData<List<D_UserMessageDTO>>($"/D_Manage/D_UserMessage/GetPageHistoryDataList", JsonConvert.SerializeObject(data));
                    if (!result.IsOK)
                    {
                        throw new Exception(result.ErrorMessage);
                    }
                    else
                    {
                        Data = new ObservableCollection<D_UserMessageDTO>(result.ResponseItem);

                    }
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

        private void SelectedUserChanged()
        {
            if (Data != null)
            {
                Data.Clear();
            }
            GetUnReadData();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _wSocketClient.MessageReceived -= _wSocketClient_MessageReceived;
            }
        }

    }
}
