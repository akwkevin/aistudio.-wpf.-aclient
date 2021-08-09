using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CHRobinson.Enterprise.Shell.Regions.Behaviors;
using DragablzPrism.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace DragablzPrism
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var view = Container.TryResolve<MainWindow>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<object, View1>("View1");
            Container.RegisterType<object, View2>("View2");
            Container.RegisterType<object, View3>("View3");

            base.ConfigureContainer();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnLastWindowClose;
            // create region
            var region = new SingleActiveRegion() { Name = RegionNames.MainRegion };

            region.Behaviors.Add(DragablzWindowBehavior.BehaviorKey, new DragablzWindowBehavior());

            Container.Resolve<RegionManager>().Regions.Add(RegionNames.MainRegion, region);

            return base.ConfigureRegionAdapterMappings();
        }
    }
}
