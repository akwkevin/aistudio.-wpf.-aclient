using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Util.Controls.Handy.Windows;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ImageBrowserViewModel : DockWindowViewModel
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

        public ImageBrowserViewModel()
        {

        }

		private void OK()
		{

		}

        public RelayCommand OpenImgCmd => new Lazy<RelayCommand>(() =>
          new RelayCommand(() =>
              new ImageBrowser(new Uri("pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/1.jpg")).Show())).Value;

    }

}
