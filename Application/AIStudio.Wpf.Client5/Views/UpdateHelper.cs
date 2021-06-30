using AIStudio.Core;
using AIStudio.Core.Helper;
using NetSparkleUpdater;
using NetSparkleUpdater.SignatureVerifiers;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace AIStudio.Wpf.Client.Views
{
    public class UpdateHelper
    {
        public static async void CheckUpdate()
        {
            try
            {
                string manifestModuleName = System.Reflection.Assembly.GetEntryAssembly().ManifestModule.FullyQualifiedName;
                var icon = System.Drawing.Icon.ExtractAssociatedIcon(manifestModuleName);

                SparkleUpdater sparkle = new SparkleUpdater(LocalSetting.UpdateAddress, new Ed25519Checker(NetSparkleUpdater.Enums.SecurityMode.Unsafe, "base_64_public_key"))
                {
                    UIFactory = new NetSparkleUpdater.UI.WPF.UIFactory(NetSparkleUpdater.UI.WPF.IconUtilities.ToImageSource(icon))
                    {
                        HideReleaseNotes = false,
                        HideSkipButton = true,
                    },
                    ShowsUIOnMainThread = true,
                };


                var sparkleInfo = await sparkle.CheckForUpdatesQuietly();
                switch (sparkleInfo.Status)
                {
                    case NetSparkleUpdater.Enums.UpdateStatus.UpdateAvailable:
                        await sparkle.CheckForUpdatesAtUserRequest();
                        break;
                    case NetSparkleUpdater.Enums.UpdateStatus.UpdateNotAvailable:
                        break;
                    case NetSparkleUpdater.Enums.UpdateStatus.UserSkipped:
                        break;
                    case NetSparkleUpdater.Enums.UpdateStatus.CouldNotDetermine:
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
