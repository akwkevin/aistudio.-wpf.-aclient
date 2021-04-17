using AIStudio.Core;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Client.ViewModels;
using AIStudio.Wpf.DataBusiness;
using AIStudio.Wpf.Home;
using AIStudio.Wpf.Home.ViewModels;
using AIStudio.Wpf.LocalConfiguration;
using AIStudio.Wpf.Service.AppClient.HttpClients;
using AutoMapper;
using Dataforge.PrismAvalonExtensions.Regions;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using ShowMeTheXAML;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;
using Xceed.Wpf.AvalonDock;


namespace AIStudio.Wpf.Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
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
            if (window.Visibility == Visibility.Collapsed || window.Visibility == Visibility.Hidden)
            {
                window = null;
            }
           
            return window;
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
                container.AddNewExtension<Interception>()//add Extension Aop
                    .RegisterSingleton<IDataProvider, ApiDataProvider>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

            }
            else//直接访问数据库模式，目前只实现了SqlServer，SQLite
            {
                container.AddNewExtension<Interception>()//add Extension Aop
                    .RegisterType(typeof(IDataProvider), typeof(EFCoreDataProvider), new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

                container.AddEFCoreServices();

                //初始化数据
                SeedData.EnsureSeedData();
            }
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //采用此种方式，是为了后续可以按照此规则自动加载模块
            var homePageModule = typeof(HomePageModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = homePageModule.Name,
                ModuleType = homePageModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(p => p.FullName.StartsWith("AIStudio.Wpf")).ToList();

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IModule).IsAssignableFrom(type))
                    {
                        if (!moduleCatalog.Modules.Any(p => p.ModuleName == type.Name))
                        {
                            moduleCatalog.AddModule(new ModuleInfo()
                            {
                                ModuleName = type.Name,
                                ModuleType = type.AssemblyQualifiedName,
                                InitializationMode = InitializationMode.WhenAvailable
                            });
                        }
                    }
                }
            }

            //var base_ManageModule = typeof(Base_ManageModule);
            //moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = base_ManageModule.Name,
            //    ModuleType = base_ManageModule.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.WhenAvailable
            //});    
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(MainWindowViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<MainWindowViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<MainWindowViewModel>());

            // generic type
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<OtherMainWindow, OtherMainWindowViewModel>();

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
            Assembly.Load("AIStudio.Wpf.Base_Manage");
            Assembly.Load("AIStudio.Wpf.D_Manage");
            Assembly.Load("AIStudio.Wpf.OA_Manage");
            Assembly.Load("AIStudio.Wpf.Quartz_Manage");

            HttpClientHelper.Instance.HandleLog = log =>
            {
                //接口日志 
                _logger.Info(LogType.系统跟踪, log);
            };

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
                    cfg.AddMaps("AIStudio.Wpf.BasePage");
                });
                return config.CreateMapper();
            }
            else
            {
                IMapper mapper = EFCoreDataProviderExtension.AddAutoMapper(new string[] { "AIStudio.Wpf.BasePage" });
                return mapper;
            }
        }
    }
}
