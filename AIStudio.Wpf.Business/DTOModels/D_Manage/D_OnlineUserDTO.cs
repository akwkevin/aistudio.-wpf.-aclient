using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Business.DTOModels
{
    public class D_OnlineUserDTO: INotifyPropertyChanged
    {
        public D_OnlineUserDTO()
        {

        }
        public D_OnlineUserDTO(string userId, string userName, string avatar)
        {
            Avatar = avatar;
            UserName = userName;
            UserId = userId;
        }

        public D_OnlineUserDTO(string groupId, string groupName, string avatar, bool isGroup, string userIds, string userNames) : this(groupId, groupName, avatar)
        {
            IsGroup = isGroup;
            UserIds = userIds;
            UserNames = userNames;
            Online = true;
        }

        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserNames { get; set; }    
        public string UserIds { get; set; }
        public string Avatar { get; set; }
        public bool Online { get; set; }
        public bool IsGroup { get; set; }

        private string _lastMessage;
        public string LastMessage
        {
            get { return _lastMessage; }
            set
            {
                if (_lastMessage != value)
                {
                    _lastMessage = value;
                    RaisePropertyChanged("LastMessage");
                }
            }
        }

        private DateTime? _lastDateTime;
        public DateTime? LastDateTime
        {
            get { return _lastDateTime; }
            set
            {
                if (_lastDateTime != value)
                {
                    _lastDateTime = value;
                    RaisePropertyChanged("LastDateTime");
                }
            }
        }
        public int Favorite { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
