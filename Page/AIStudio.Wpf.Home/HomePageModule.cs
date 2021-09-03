using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using AIStudio.Wpf.Home.Views;
using AIStudio.Core;
using System.Reflection;
using Util.Controls;
using System.Windows.Controls;
using System;
using System.Windows;
using ShowMeTheXAML;
using AIStudio.Wpf.LayoutPage.Views;
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

            //regionManager.RequestNavigate(RegionName.MainContentRegion, "FullScreenView", paras);
        
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainView>();
            containerRegistry.RegisterForNavigation<FullScreenView>();
            containerRegistry.RegisterForNavigation(typeof(IntroduceView), typeof(IntroduceView).FullName);
            containerRegistry.RegisterForNavigation(typeof(UserConsoleView), typeof(UserConsoleView).FullName);
            containerRegistry.RegisterForNavigation(typeof(_3DShowcaseView), typeof(_3DShowcaseView).FullName); 
        }
    }
}
