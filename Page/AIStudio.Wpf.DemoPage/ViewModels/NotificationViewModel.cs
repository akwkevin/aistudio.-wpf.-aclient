using AIStudio.Wpf.DemoPage.Views;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Util.Controls.Handy;
using Util.Controls.Handy.Data;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class NotificationViewModel : DockWindowViewModel
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

        public NotificationViewModel()
        {

        }

		private void OK()
		{

		}

        public RelayCommand OpenCmd => new Lazy<RelayCommand>(() =>
           new RelayCommand(() => Notification.Show(new AppNotification(), ShowAnimation, StaysOpen))).Value;


        private ShowAnimation _showAnimation;

        public ShowAnimation ShowAnimation
        {
            get { return _showAnimation; }
            set
            {
                if (_showAnimation != value)
                {
                    _showAnimation = value;
                    RaisePropertyChanged("ShowAnimation");
                }
            }
        }

        private bool _staysOpen = true;

        public bool StaysOpen
        {
            get { return _staysOpen; }
            set
            {
                if (_staysOpen != value)
                {
                    _staysOpen = value;
                    RaisePropertyChanged("StaysOpen");
                }
            }
        }

    }

}
