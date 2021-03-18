using AIStudio.Core;
using AIStudio.Wpf.Business;
using AutoUpdaterDotNET;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using Util.Controls;

namespace AIStudio.Wpf.Client.Views
{
    /// <summary>
    /// UpdateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateWindow : WindowBase
    {
        ILogger _logger { get; }

        public UpdateWindow(ILogger logger)
        {
            InitializeComponent();

            _logger = logger;

            this.Visibility = Visibility.Collapsed;
            this.Loaded += UpdateWindow_OnLoaded;
        }

        private void UpdateWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                CurrentVersion.Text = $"Current Version: {assembly.GetName().Version}";
                LocalSetting.SetAppSetting("Version", assembly.GetName().Version.ToString());

                Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("zh");
                AutoUpdater.LetUserSelectRemindLater = true;
                AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Minutes;
                AutoUpdater.RemindLaterAt = 1;
                AutoUpdater.ReportErrors = false;
                AutoUpdater.Synchronous = true;
                AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
                AutoUpdater.Start(LocalSetting.UpdateAddress);

                
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, LogType.系统异常, ex.ToString());
            }

            if (IsVisible)
            {
                this.DialogResult = true;
            }

        }

        private void AutoUpdater_ApplicationExitEvent()
        {
            this.DialogResult = false;
        }
    }
}
