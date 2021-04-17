using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Util.Controls.Handy;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class SearchBarViewModel : DockWindowViewModel
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

        public SearchBarViewModel()
        {

        }

		private void OK()
		{

		}

        public RelayCommand<string> SearchCmd => new Lazy<RelayCommand<string>>(() =>
          new RelayCommand<string>(Search)).Value;

        private void Search(string key)
        {
            Growl.Info(key);
        }

    }

}
