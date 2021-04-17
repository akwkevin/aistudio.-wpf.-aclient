using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ScreenshotViewModel : DockWindowViewModel
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

        private ICommand startScreenshot;
        public ICommand StartScreenshot
        {
            get
            {
                return this.startScreenshot ?? (this.startScreenshot = new DelegateCommand(() => this.Screenshot()));
            }
        }

        private void Screenshot()
        {
            ComeCapture.MainWindow window = new ComeCapture.MainWindow();
            window.Show();
        }

        public ScreenshotViewModel()
        {

        }

		private void OK()
		{

		}

    }

}
