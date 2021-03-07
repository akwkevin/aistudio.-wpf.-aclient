using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls.Commands;
using System.Windows.Input;
using System.Windows;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class SearchBarViewModel : Dataforge.PrismAvalonExtensions.ViewModels.DockWindowViewModel
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
