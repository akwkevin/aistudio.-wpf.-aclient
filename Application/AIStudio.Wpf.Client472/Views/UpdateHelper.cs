using AIStudio.Core;
using Squirrel;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace AIStudio.Wpf.Client.Views
{
    public class UpdateHelper
    {
        public static async void CheckUpdate()
        {
            //http://192.168.0.5:8080/SquirrelReleases
            try
            {
                using (var updateManager = new UpdateManager(LocalSetting.UpdateAddress))
                {
                    LocalSetting.SetAppSetting("Version", updateManager.CurrentlyInstalledVersion().ToString());

                    var releaseEntry = await updateManager.UpdateApp();

                    if (releaseEntry != null)
                    {
                        var r = System.Windows.MessageBox.Show($"当前版本{updateManager.CurrentlyInstalledVersion()}，检测到新版本{releaseEntry.Version}，是否重启更新？");
                        if (r == MessageBoxResult.OK)
                        {
                            UpdateManager.RestartApp();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

        }

    }
}
