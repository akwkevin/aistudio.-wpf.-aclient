using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Client.Views;
using AIStudio.Wpf.Service.IWebSocketClient;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Input;
using Util.Controls;

namespace AIStudio.Wpf.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        IRegionManager _regionManager { get; }
        private IEventAggregator _eventAggregator { get; }
        IWSocketClient _wSocketClient { get; }
        ILogger _logger { get; }
        IModuleManager _moduleManager { get; }

        public MainWindow(IRegionManager regionManager, IModuleManager moduleManager, IEventAggregator eventAggregator, IWSocketClient wSocketClient, ILogger logger)
        {
            HomePage.ViewModels.SystemSetViewModel.InitSetting();

            InitializeComponent();

            _regionManager = regionManager;
            _moduleManager = moduleManager;
            _eventAggregator = eventAggregator;
            _wSocketClient = wSocketClient;
            _logger = logger;

            ShowLogin();                         
        }


        private void ShowLogin()
        {
            this.Hide();

            UpdateWindow update = new UpdateWindow(_logger);
            if (update.ShowDialog() == false)
            {
                Application.Current.Shutdown();
                return;
            }

            LoginWindow login = new LoginWindow();
            if (login.ShowDialog() == false)
            {
                Application.Current.Shutdown();
                return;
            }

            this.Show();
          
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBoxHelper.ShowSure("确定要退出系统?", this);
            if (result != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                _wSocketClient.Dispose();
                System.Windows.Application.Current.Shutdown();
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        int index = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }
            index = 1;

            flyout.IsOpen = !flyout.IsOpen;
        }


        private ICommand keyCommand;
        public ICommand KeyCommand
        {
            get
            {
                return this.keyCommand ?? (this.keyCommand = new DelegateCommand<string>(para => this.KeyExcute(para)));
            }
        }

        private void KeyExcute(string para)
        {
            _eventAggregator.GetEvent<KeyExcuteEvent>().Publish(new Tuple<string, string>(Identifier.ToString(), para));
        }
    }
}
