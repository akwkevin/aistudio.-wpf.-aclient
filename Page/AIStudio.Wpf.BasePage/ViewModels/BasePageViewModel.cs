using AIStudio.Core;
using AIStudio.Wpf.Controls;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Wpf.BasePage.ViewModels
{
    public class BasePageViewModel : NavigationDockWindowViewModel
    {
        protected string Identifier { get; set; } = LocalSetting.RootWindow;

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            var identifier = navigationContext.Parameters["Identifier"] as string;
            if (!string.IsNullOrEmpty(identifier))
            {
                Identifier = identifier;
            }
        }

        protected void ShowWait()
        {
            WindowBase.ShowWaiting(WaitingStyle.Busy, Identifier, "正在获取数据");
        }

        protected void HideWait()
        {
            WindowBase.HideWaiting(Identifier);
        }
    }
}
