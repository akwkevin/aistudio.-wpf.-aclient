using Accelerider.Extensions.Mvvm;
using AIStudio.AOP;
using AIStudio.Core;
using AIStudio.Wpf.Agile_Development;
using AIStudio.Wpf.ApiBusiness;
using AIStudio.Wpf.Base_Manage;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Client;
using AIStudio.Wpf.Client.ViewModels;
using AIStudio.Wpf.D_Manage;
using AIStudio.Wpf.Home;
using AIStudio.Wpf.Home.ViewModels;
using AIStudio.Wpf.Home.Views;
using AIStudio.Wpf.Home_Dev.MainViews;
using AIStudio.Wpf.OA_Manage;
using AIStudio.Wpf.Protobuf_Test;
using AIStudio.Wpf.ProtobufApi;
using AIStudio.Wpf.Quartz_Manage;
using Castle.DynamicProxy;
using DryIoc.Microsoft.DependencyInjection.Extension;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;

namespace AIStudio.Wpf.Client_Dev
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : AIStudio.Wpf.Client.App
    {   
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);
            //api接口模式
            if (LocalSetting.ApiMode)
            {
                containerRegistry.RegisterSingleton<IDataProvider, ProtobufDataProvider>("Protobuf");

                //有空研究下如何命名AOP注入
                //containerRegistry.GetContainer().RegisterServices(services =>
                //{
                //    //注入AOP
                //    services.Add(new ServiceDescriptor(typeof(IDataProvider), serviceProvider =>
                //    {
                //        CastleInterceptor castleInterceptor = new CastleInterceptor(serviceProvider);

                //        return _generator.CreateInterfaceProxyWithTarget(typeof(IDataProvider), serviceProvider.GetService<ProtobufDataProvider>(), castleInterceptor);
                //    }, ServiceLifetime.Singleton));
                //});
            }          
        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var homePageModule = typeof(HomeDevModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = homePageModule.Name,
                ModuleType = homePageModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var base_ManageModule = typeof(Base_ManageModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = base_ManageModule.Name,
                ModuleType = base_ManageModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var d_ManageModule = typeof(D_ManageModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = d_ManageModule.Name,
                ModuleType = d_ManageModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var oa_ManageModule = typeof(OA_ManageModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = oa_ManageModule.Name,
                ModuleType = oa_ManageModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var quartz_ManageModule = typeof(Quartz_ManageModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = quartz_ManageModule.Name,
                ModuleType = quartz_ManageModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var debug_ToolModule = typeof(Agile_DevelopmentModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = debug_ToolModule.Name,
                ModuleType = debug_ToolModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var protobuf_TestModule = typeof(Protobuf_TestModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = protobuf_TestModule.Name,
                ModuleType = protobuf_TestModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        protected override void ConfigureViewModelLocator()
        {
            //base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewModelFactory(new ViewModelResolver(() => Container)
                 .UseDefaultConfigure()
                 .ResolveViewModelForView);

            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(MainWindowViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<MainWindowViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<MainWindowViewModel>());

            // generic type
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<OtherMainWindow, OtherMainWindowViewModel>();
            ViewModelLocationProvider.Register<MainView, MainDevViewModel>();

            //自定义目录结构
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //{
            //    var viewName = viewType.FullName;
            //    var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //    var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
            //    return Type.GetType(viewModelName);
            //});
        }

    }
}
