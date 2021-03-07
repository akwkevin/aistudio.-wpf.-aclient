using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls.Commands;
using System.Windows.Input;
using Util.Controls;
using Util.Controls.Data;
using System.Windows;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class NotifyIconViewModel : Dataforge.PrismAvalonExtensions.ViewModels.DockWindowViewModel
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

		private ICommand okCommand;
        public ICommand OKCommand
        {
            get
            {
                return this.okCommand ?? (this.okCommand = new DelegateCommand(() => this.OK()));
            }
        }

        public NotifyIconViewModel()
        {

        }

		private void OK()
		{

		}

        public static bool NotifyIconIsShow { get; set; }

        private bool _reversed;

        private string _content = "Hello~~~";

        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    RaisePropertyChanged("Content");
                }
            }
        }

        private bool _contextMenuIsShow;

        public bool ContextMenuIsShow
        {
            get { return _contextMenuIsShow; }
            set
            {
                if (_contextMenuIsShow != value)
                {
                    _contextMenuIsShow = value;
                    RaisePropertyChanged("ContextMenuIsShow");
                    NotifyIconIsShow = ContextMenuIsShow || ContextContentIsShow;
                    if (!_reversed)
                    {
                        _reversed = true;
                        ContextContentIsShow = !value;
                        _reversed = false;
                    }
                }
            }
        }

        private bool _contextMenuIsBlink;

        public bool ContextMenuIsBlink
        {
            get { return _contextMenuIsBlink; }
            set
            {
                if (_contextMenuIsBlink != value)
                {
                    _contextMenuIsBlink = value;
                    RaisePropertyChanged("ContextMenuIsBlink");
                }
            }
        }

        private bool _contextContentIsShow;

        public bool ContextContentIsShow
        {
            get { return _contextContentIsShow; }
            set
            {
                if (_contextContentIsShow != value)
                {
                    _contextContentIsShow = value;
                    RaisePropertyChanged("ContextContentIsShow");
                    NotifyIconIsShow = ContextMenuIsShow || ContextContentIsShow;
                    if (!_reversed)
                    {
                        _reversed = true;
                        ContextMenuIsShow = !value;
                        _reversed = false;
                    }
                }
            }
        }

        private bool _contextContentIsBlink;

        public bool ContextContentIsBlink
        {
            get { return _contextContentIsBlink; }
            set
            {
                if (_contextContentIsBlink != value)
                {
                    _contextContentIsBlink = value;
                    RaisePropertyChanged("ContextContentIsBlink");
                }
            }
        }

        public RelayCommand<object> MouseCmd => new Lazy<RelayCommand<object>>(() =>
            new RelayCommand<object>(str => Growl.Info(str.ToString()))).Value;

        public RelayCommand SendNotificationCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(SendNotification)).Value;

        private void SendNotification()
        {
            NotifyIcon.ShowBalloonTip("HandyControl", Content, NotifyIconInfoType.None, ContextMenuIsShow ? "NotifyIconDemo" : "NotifyIconContextDemo");
        }

    }

}
