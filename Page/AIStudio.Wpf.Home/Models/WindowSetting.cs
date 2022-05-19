using AIStudio.Core.Models;
using System;
using System.Configuration;

namespace AIStudio.Wpf.Home.Models
{
    public class WindowSetting : BindableBase
    {

        private string _navigationLoaction;
        public string NavigationLocation
        {
            get { return _navigationLoaction; }
            set
            {
                SetProperty(ref _navigationLoaction, value);
            }
        }       

        private string _toolBarLocation;
        public string ToolBarLocation
        {
            get { return _toolBarLocation; }
            set
            {
                SetProperty(ref _toolBarLocation, value);
            }
        }

        private string _statusBarLocation;
        public string StatusBarLocation
        {
            get { return _statusBarLocation; }
            set
            {
                SetProperty(ref _statusBarLocation, value);
            }
        }
    }

}
