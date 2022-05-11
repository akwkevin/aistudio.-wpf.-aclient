using Accelerider.Extensions.Mvvm;
using AIStudio.LocalConfiguration;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Service.AppClient.HttpClients;
using Dataforge.PrismAvalonExtensions;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Windows;
using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;

namespace ServiceMonitor
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
            return window;
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IOperator, Operator>();
            containerRegistry.RegisterSingleton<IUserData, UserData>();
            containerRegistry.RegisterSingleton<IWSocketClient, WSocketClient>();
            containerRegistry.RegisterSingleton<IUserConfig, UserConfig>();
            containerRegistry.Register<ILogger, Logger>();

 
            var container = PrismIocExtensions.GetContainer(containerRegistry);
            //api接口模式

                container.AddNewExtension<Interception>()//add Extension Aop
                    .RegisterSingleton<IDataProvider, ApiDataProvider>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

    
        }


        protected override void ConfigureViewModelLocator()
        {
            //base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewModelFactory(new ViewModelResolver(() => Container)
                 .UseDefaultConfigure()
                 .ResolveViewModelForView);

            // generic type
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();

        }


        protected override void OnStartup(StartupEventArgs e)
        {
            HttpClientHelper.Instance.HandleLog = log =>
            {
                //接口日志 
                _logger.Info(LogType.系统跟踪, log);
            };

            base.OnStartup(e);
        }


    }
}
