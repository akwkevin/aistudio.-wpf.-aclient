﻿using Dataforge.PrismAvalonExtensions.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Controls.Commands;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.ViewModels
{
    public class LazyLoadedViewModel : DockWindowViewModel
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

        private bool _startLoaded;
        public bool StartLoaded
        {
            get { return _startLoaded; }
            set
            {
                if (_startLoaded != value)
                {
                    SetProperty(ref _startLoaded, value);
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

        public LazyLoadedViewModel()
        {

        }

		private void OK()
		{
            StartLoaded = true;

        }

    }

}
