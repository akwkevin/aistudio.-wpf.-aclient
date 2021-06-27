using AIStudio.Core;
using AIStudio.Wpf.Business;
using NetSparkleUpdater;
using NetSparkleUpdater.SignatureVerifiers;
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
            SparkleUpdater _sparkle;
            // set icon in project properties!
            string manifestModuleName = System.Reflection.Assembly.GetEntryAssembly().ManifestModule.FullyQualifiedName;
            var icon = System.Drawing.Icon.ExtractAssociatedIcon(manifestModuleName);
            _sparkle = new SparkleUpdater(@"F:\框架\akwkevin-NetSparkle-master\NetSparkle\Extras\Sample Update AppCast\Server Root\versioninfo.xml", new DSAChecker(NetSparkleUpdater.Enums.SecurityMode.Strict))
            {
                UIFactory = new NetSparkleUpdater.UI.WPF.UIFactory(NetSparkleUpdater.UI.WPF.IconUtilities.ToImageSource(icon)),
                ShowsUIOnMainThread = false,
                //RelaunchAfterUpdate = true,
                //UseNotificationToast = true
            };
            // TLS 1.2 required by GitHub (https://developer.github.com/changes/2018-02-01-weak-crypto-removal-notice/)
            _sparkle.SecurityProtocolType = System.Net.SecurityProtocolType.Tls12;
            _sparkle.StartLoop(true, true);

            await _sparkle.CheckForUpdatesAtUserRequest();

            this.DialogResult = true;
        }
    }
}
