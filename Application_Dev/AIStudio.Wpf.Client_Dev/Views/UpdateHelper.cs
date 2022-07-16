using AIStudio.Core;
using AutoUpdaterDotNET;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace AIStudio.Wpf.Client_Dev.Views
{
    public class UpdateHelper
    {
        public static void CheckUpdate()
        {
            try
            {
                Assembly assembly = Assembly.GetEntryAssembly();
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
            catch  {}
        }

        private static void AutoUpdater_ApplicationExitEvent()
        {
           
        }
    }
}
