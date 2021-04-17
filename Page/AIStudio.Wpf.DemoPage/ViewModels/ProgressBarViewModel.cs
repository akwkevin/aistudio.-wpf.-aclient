using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ProgressBarViewModel : DockWindowViewModel
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

        private readonly DispatcherTimer _timer;

        public ProgressBarViewModel()
        {

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Progress++;
            if (Progress == 100)
            {
                Progress = 0;
                _timer.Stop();
                IsUploading = false;
            }
        }

        public void ButtonProgress_OnClick(object sender, RoutedEventArgs e)
        {
            if (_timer.IsEnabled)
            {
                _timer.Stop();
            }
            else
            {
                _timer.Start();
            }
        }

        private bool _isUploading;
        public bool IsUploading
        {
            get { return _isUploading; }
            set
            {
                if (_isUploading != value)
                {
                    _isUploading = value;
                    RaisePropertyChanged("IsUploading");
                }
            }
        }

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    RaisePropertyChanged("Progress");
                }
            }
        }

        private void OK()
		{

		}

    }

}
