using AIStudio.Wpf.PrismDragablzExtensions.Regions;
using Dataforge.PrismAvalonExtensions.Regions;
using Dataforge.PrismAvalonExtensions.Test.Views;
using Dragablz;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using Xceed.Wpf.AvalonDock;

namespace Dataforge.PrismAvalonExtensions.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleTestModule>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<DockingManagerRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(TabablzControl), Container.Resolve<TabablzControlRegionAdapter>());
        }
    }
}
