using AIStudio.Core;
using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Net.Http;
using System.Windows.Input;

namespace AIStudio.Wpf.Client.ViewModels
{
    class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
           
        }

        private string _identifier = LocalSetting.RootWindow;
        public string Identifier
        {
            get { return _identifier; }
            set
            {
                SetProperty(ref _identifier, value);
            }
        }
    }
}
