using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dragablz;
using DragablzPrism.Regions;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace DragablzPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public ICommand OpenView1 { get; }
        public ICommand OpenView2 { get; }
        public ICommand OpenView3 { get; }
        public IInterTabClient InterTabClient { get; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            OpenView1 = new DelegateCommand(OpenView1Action);
            OpenView2 = new DelegateCommand(OpenView2Action);
            OpenView3 = new DelegateCommand(OpenView3Action);
            InterTabClient = new InterTabClient();
        }

        private void OpenView3Action()
        {
            this.regionManager.RequestNavigate(RegionNames.MainRegion, "View3");
        }

        private void OpenView2Action()
        {
            this.regionManager.RequestNavigate(RegionNames.MainRegion, "View2");
        }

        private void OpenView1Action()
        {
            this.regionManager.RequestNavigate(RegionNames.MainRegion, "View1");
        }
    }
}
