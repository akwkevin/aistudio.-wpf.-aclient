using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace AIStudio.Wpf.HomePage.ViewModels
{
    public class OtherMainWindowViewModel : BindableBase
    {      
        IEventAggregator _eventAggregator { get; }

        public OtherMainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }




    }
}
