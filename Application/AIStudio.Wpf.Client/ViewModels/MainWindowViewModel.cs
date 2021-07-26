using AIStudio.Core;
using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace AIStudio.Wpf.Client.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        IModuleManager _moduleManager { get; }
        IRegionManager _regionManager { get; }
        IEventAggregator _eventAggregator { get; }
        IOperator _operator { get; }
        IWSocketClient _wSocketClient { get; }

        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IEventAggregator eventAggregator, IOperator ioperator, IWSocketClient wSocketClient)
        {
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            _operator = ioperator;
            _eventAggregator = eventAggregator;
            _wSocketClient = wSocketClient;
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

        public void Loaded()
        {
            _moduleManager.LoadModule("HomePageModule");
        }

        public void Dispose()
        {
            _wSocketClient.Dispose();
        }

    }
}
