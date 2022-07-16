using Accelerider.Extensions.Mvvm;
using AIStudio.AOP;
using AIStudio.LocalConfiguration;
using AIStudio.Wpf.ApiBusiness;
using AIStudio.Wpf.Business;
using Castle.DynamicProxy;
using Dataforge.PrismAvalonExtensions;
using DryIoc.Microsoft.DependencyInjection.Extension;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Windows;

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

        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IOperator, Operator>();
            containerRegistry.RegisterSingleton<IUserData, UserData>();
            containerRegistry.RegisterSingleton<IWSocketClient, WSocketClient>();
            containerRegistry.RegisterSingleton<IUserConfig, UserConfig>();
            containerRegistry.Register<ILogger, Logger>();
            //api接口模式

            containerRegistry.GetContainer().RegisterServices(services =>
            {
                //注入AOP
                services.Add(new ServiceDescriptor(typeof(IDataProvider), serviceProvider =>
                {
                    CastleInterceptor castleInterceptor = new CastleInterceptor(serviceProvider);

                    return _generator.CreateInterfaceProxyWithTarget(typeof(IDataProvider), serviceProvider.GetService(typeof(ApiDataProvider)), castleInterceptor);
                }, ServiceLifetime.Singleton));

                services.AddHttpClient();
            });
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

    }
}
