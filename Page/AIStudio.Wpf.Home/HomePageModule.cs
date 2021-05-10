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
            containerRegistry.RegisterForNavigation(typeof(UserConsoleView), typeof(UserConsoleView).FullName);
            containerRegistry.RegisterForNavigation(typeof(_3DShowcaseView), typeof(_3DShowcaseView).FullName);

#if DEBUG
            Assembly assembly = Assembly.Load("AIStudio.Wpf.DemoPage");

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(BaseDialog)) && type.IsSubclassOf(typeof(UserControl)))
                {
                    containerRegistry.RegisterForNavigation(type, type.FullName);
                }
            }

            XamlDisplay.Init(assembly);

            string xamlDisplayResourceCulture = @"/AIStudio.Wpf.DemoPage;component/Resources/XamlDisplayResource.xaml";
            ResourceDictionary xamlDisplayResourceDictionary = new ResourceDictionary();
            xamlDisplayResourceDictionary.Source = new Uri(xamlDisplayResourceCulture, UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(xamlDisplayResourceDictionary);

            string demoStyleResourceCulture = @"/AIStudio.Wpf.DemoPage;component/Resources/DemoStyleResource.xaml";
            ResourceDictionary demoStyleResourceDictionary = new ResourceDictionary();
            demoStyleResourceDictionary.Source = new Uri(demoStyleResourceCulture, UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(demoStyleResourceDictionary);
#endif       
        }
    }
}
