using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class FontAwesomeViewModel : DockWindowViewModel
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

        public FontAwesomeViewModel()
        {

        }

		private void OK()
		{

		}

    }

}
