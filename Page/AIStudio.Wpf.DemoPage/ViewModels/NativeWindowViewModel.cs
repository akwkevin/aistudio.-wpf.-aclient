using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class NativeWindowViewModel : DockWindowViewModel
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

        public NativeWindowViewModel()
        {

        }

		private void OK()
		{

		}

        public RelayCommand<string> OpenWindowCmd => new Lazy<RelayCommand<string>>(() => new RelayCommand<string>(OpenWindow)).Value;

        private void OpenWindow(string windowTag)
        {
            var type = Type.GetType($"{"AIStudio.Wpf.DemoPage.Views"}.{windowTag}");
            var window = type == null ? null : Activator.CreateInstance(type) as System.Windows.Window;
            if (window != null)
            {
                window.Owner = Application.Current.MainWindow;
                window.ShowDialog();
            }
        }

    }

}
