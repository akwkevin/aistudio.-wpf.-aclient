using AIStudio.Core;
using AIStudio.Wpf.Business;
using Squirrel;
using System;
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

        private async void UpdateWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //http://192.168.0.5:8080/SquirrelReleases
            try
            {
                using (var updateManager = new UpdateManager(LocalSetting.UpdateAddress))
                {
                    CurrentVersion.Text = $"Current version: {updateManager.CurrentlyInstalledVersion()}";

                    LocalSetting.SetAppSetting("Version", updateManager.CurrentlyInstalledVersion().ToString());

                    var releaseEntry = await updateManager.UpdateApp();
                    NewVersion.Text = $"Update Version: {releaseEntry?.Version.ToString() ?? "No update"}";
                    if (releaseEntry != null)
                    {
                        this.Visibility = Visibility.Visible;
                        var r = System.Windows.MessageBox.Show("检测到新版本，是否重启更新？");
                        if (r == MessageBoxResult.OK)
                        {
                            UpdateManager.RestartApp();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, LogType.系统异常, ex.ToString());
            }

            this.DialogResult = true;
        }
    }
}
