using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class ControlNavigationViewModel : DockWindowViewModel
    {
        private ObservableCollection<string> _data;
        public ObservableCollection<string> Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
					SetProperty(ref _data, value);
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

        public ControlNavigationViewModel()
        {

        }

		private void OK()
		{

		}

    }

}
