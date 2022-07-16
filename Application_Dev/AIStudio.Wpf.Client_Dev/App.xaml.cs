﻿using Accelerider.Extensions.Mvvm;
using AIStudio.Core;
using AIStudio.LocalConfiguration;
using AIStudio.Wpf.Agile_Development;
using AIStudio.Wpf.ApiBusiness;
using AIStudio.Wpf.Base_Manage;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Client_Dev;
using AIStudio.Wpf.Client_Dev.ViewModels;
using AIStudio.Wpf.Client_Dev.Views;
using AIStudio.Wpf.D_Manage;
using AIStudio.Wpf.DataBusiness;
using AIStudio.Wpf.Home;
using AIStudio.Wpf.Home.ViewModels;
using AIStudio.Wpf.Home.Views;
using AIStudio.Wpf.Home_Dev.MainViews;
using AIStudio.Wpf.OA_Manage;
using AIStudio.Wpf.Protobuf_Test;
using AIStudio.Wpf.ProtobufApi;
using AIStudio.Wpf.Quartz_Manage;
using AutoMapper;
using Dataforge.PrismAvalonExtensions;
using Dataforge.PrismAvalonExtensions.Regions;
using DryIoc.Microsoft.DependencyInjection.Extension;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using Unity;
using Xceed.Wpf.AvalonDock;

namespace AIStudio.Wpf.Client_Dev
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : MyPrismApplication
    {
        public App()
        {
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Application_DispatcherUnhandledException;


        }

        #region ILogger
        private ILogger _logger { get => ContainerLocator.Current.Resolve<ILogger>(); }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //记录严重错误 
            _logger.Error(e.Exception);
            Application.Current.Dispatcher.Invoke((Action)delegate ()
            {
                Controls.MessageBox.Error(e.Exception.Message);
            });
            e.Handled = true;//使用这一行代码告诉运行时，该异常被处理了，不再作为UnhandledException抛出了。            
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    _logger.Error(exception);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                //ignore
            }
            //记录严重错误                  

        }
        #endregion

        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            //加载主题
            Home.ViewModels.SystemSetViewModel.InitSetting();
            return window;
        }


        protected override void InitializeShell(Window shell)
        {

#if !DEBUG
                 //升级
            UpdateHelper.CheckUpdate();
#endif


            //登录
            LoginWindow login = new LoginWindow();
            if (login.ShowDialog() == false)
            {
                if (Application.Current != null)
                {
                    Application.Current.Shutdown();
                }
                return;
            }

            base.InitializeShell(shell);
        }



        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IOperator, Operator>();
            containerRegistry.RegisterSingleton<IUserData, UserData>();
            containerRegistry.RegisterSingleton<IWSocketClient, WSocketClient>();
            containerRegistry.RegisterSingleton<IUserConfig, UserConfig>();
            containerRegistry.Register<ILogger, Logger>();

            //AutoMapper            
            containerRegistry.RegisterInstance<IMapper>(new MapperProvider(containerRegistry).GetMapper());//containerRegistry.RegisterInstance(typeof(IMapper), new MapperProvider(containerRegistry).GetMapper());

            var container = PrismIocExtensions.GetContainer(containerRegistry);
            //api接口模式
            if (LocalSetting.ApiMode)
            {
                //container.AddNewExtension<Interception>()//add Extension Aop
                //    .RegisterSingleton<IDataProvider, ApiDataProvider>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

                containerRegistry.RegisterSingleton<IDataProvider, ApiDataProvider>();
                containerRegistry.RegisterSingleton<IDataProvider, ProtobufDataProvider>("Protobuf");     
           
                containerRegistry.GetContainer().RegisterServices(services =>
                {
                    services.AddHttpClient();
                });
            }
            else//直接访问数据库模式，目前只实现了SqlServer，SQLite
            {
                containerRegistry.RegisterSingleton<IDataProvider, EFCoreDataProvider>();
                containerRegistry.GetContainer().RegisterServices(services =>
                {
                    services.AddEFCoreServices();
                });

                //初始化数据
                SeedData.EnsureSeedData();
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

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<DockingManagerRegionAdapter>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //HttpClientHelper.Instance.HandleLog = log =>
            //{
            //    //接口日志 
            //    _logger.Info(LogType.系统跟踪, log);
            //};



            base.OnStartup(e);
        }


    }
    public interface IMapperProvider
    {
        IMapper GetMapper();
    }
    public class MapperProvider : Profile, IMapperProvider
    {
        private readonly IContainerRegistry _container;

        public MapperProvider(IContainerRegistry container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            if (LocalSetting.ApiMode)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps("AIStudio.Wpf.BasePage", "AIStudio.Core", "AIStudio.Wpf.LayoutPage");
                });
                return config.CreateMapper();
            }
            else
            {
                IMapper mapper = EFCoreDataProviderExtension.AddAutoMapper(new string[] { "AIStudio.Wpf.BasePage", "AIStudio.Core", "AIStudio.Wpf.LayoutPage" });
                return mapper;
            }
        }
    }
}
