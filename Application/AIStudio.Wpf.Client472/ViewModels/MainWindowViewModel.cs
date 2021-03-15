using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace AIStudio.Wpf.Client.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        IModuleManager _moduleManager { get; }
        IRegionManager _regionManager { get; }
        IEventAggregator _eventAggregator { get; }
        IOperator _operator { get; }

        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IEventAggregator eventAggregator, IOperator ioperator)
        {
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            _operator = ioperator;
            _eventAggregator = eventAggregator;

            //var xx = ContainerLocator.Current.Resolve(typeof(IEventAggregator));
            //var xx2 = ContainerLocator.Current.Resolve<IEventAggregator>();
        }



    }
}
