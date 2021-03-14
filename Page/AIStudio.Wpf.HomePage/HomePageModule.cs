using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using AIStudio.Wpf.Home.Views;
using AIStudio.Core;
using System.Reflection;
using Util.Controls;
using System.Windows.Controls;

namespace AIStudio.Wpf.Home
{
    public class HomePageModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {        
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion(RegionName.MainContentRegion, typeof(MainView));
            NavigationParameters paras = new NavigationParameters();
            paras.Add("Identifier", LocalSetting.RootWindow);
            regionManager.RequestNavigate(RegionName.MainContentRegion, "MainView", paras);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainView>();
            containerRegistry.RegisterForNavigation(typeof(IntroduceView), typeof(IntroduceView).FullName);

#if DEBUG
            Assembly assembly = Assembly.Load("AIStudio.Wpf.DemoPage");
            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(BaseDialog)) && type.IsSubclassOf(typeof(UserControl)))
                {
                    containerRegistry.RegisterForNavigation(type, type.FullName);
                }
            }
#endif
        }
    }
}
