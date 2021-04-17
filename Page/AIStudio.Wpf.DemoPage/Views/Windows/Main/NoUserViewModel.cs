using System;
using System.Windows;
using Prism.Mvvm;

namespace AIStudio.Wpf.DemoPage.Views
{
    public class NoUserViewModel : BindableBase
    {
        public RelayCommand<string> OpenViewCmd => new Lazy<RelayCommand<string>>(() =>
            new RelayCommand<string>(OpenView)).Value;

        private void OpenView(string viewName)
        {
            if (LoadShowContent != null)
            {
                LoadShowContent(viewName);
            }
        }

        public Action<string> LoadShowContent;
    }
}