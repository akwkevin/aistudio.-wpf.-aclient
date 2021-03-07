using Dataforge.PrismAvalonExtensions.ViewModels;
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

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class MediaPlayerViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> _data;
        public ObservableCollection<string> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    RaisePropertyChanged("Data");
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

        public MediaPlayerViewModel()
        {

        }

		private void OK()
		{

		}


        private ICommand _openMediaElement;
        public ICommand OpenMediaElement
        {
            get
            {
                return this._openMediaElement ?? (this._openMediaElement = new DelegateCommand<string>(para => this.OpenMedia(para)));
            }
        }

        private void OpenMedia(string para)
        {
            if (para == "Video")
            {
                MediaElementPlayerWindow.Show($"{System.AppDomain.CurrentDomain.BaseDirectory}/Resources/Media/intro.wmv", ShowMode.PathVideoMode);
            }
            else
            {
                MediaElementPlayerWindow.Show($"{System.AppDomain.CurrentDomain.BaseDirectory}/Resources/Media/intro.wmv");
            }
        }
    }

}
