using AIStudio.Wpf.DemoPage.Views;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ChatBubbleViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> data;
        public ObservableCollection<string> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    RaisePropertyChanged("Data");
                }
            }
        }

        private ObservableCollection<ChatInfoModel> _leftChatInfos = new ObservableCollection<ChatInfoModel>();
        public ObservableCollection<ChatInfoModel> LeftChatInfos
        {
            get { return _leftChatInfos; }
            set
            {
                if (_leftChatInfos != value)
                {
                    _leftChatInfos = value;
                    RaisePropertyChanged("LeftChatInfos");
                }
            }
        }

        private ObservableCollection<ChatInfoModel> _rightChatInfos = new ObservableCollection<ChatInfoModel>();
        public ObservableCollection<ChatInfoModel> RightChatInfos
        {
            get { return _rightChatInfos; }
            set
            {
                if (_rightChatInfos != value)
                {
                    _rightChatInfos = value;
                    RaisePropertyChanged("RightChatInfos");
                }
            }
        }

        private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return this._okCommand ?? (this._okCommand = new DelegateCommand(() => this.OK()));
            }
        }

        private ICommand _leftSendComamnd;
        public ICommand LeftSendComamnd
        {
            get
            {
                return this._leftSendComamnd ?? (this._leftSendComamnd = new DelegateCommand<RoutedEventArgs>(para => this.LeftSend(para)));
            }
        }

        private ICommand _rightSendComamnd;
        public ICommand RightSendComamnd
        {
            get
            {
                return this._rightSendComamnd ?? (this._rightSendComamnd = new DelegateCommand<RoutedEventArgs>(para => this.RightSend(para)));
            }
        }

        public ChatBubbleViewModel()
        {

        }

		private void OK()
		{

		}

        private void LeftSend(RoutedEventArgs para)
        {
            ChatSendEventArgs args = para as ChatSendEventArgs;
            if (args != null)
            {
                var content = args.Content;
                LeftChatInfos.Add(content);
                content.Role = "Receiver";
                RightChatInfos.Add(content);
            }
        }

        private void RightSend(RoutedEventArgs para)
        {
            ChatSendEventArgs args = para as ChatSendEventArgs;
            if (args != null)
            {
                var content = args.Content;
                RightChatInfos.Add(content);
                content.Role = "Receiver";
                LeftChatInfos.Add(content);
            }
        }
    }

}
