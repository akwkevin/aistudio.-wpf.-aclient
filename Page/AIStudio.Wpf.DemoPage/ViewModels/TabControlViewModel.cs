﻿using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class TabControlViewModel : DockWindowViewModel
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

        public TabControlViewModel()
        {

        }

		private void OK()
		{

		}

    }

}
