using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Client.ViewModels;
using AIStudio.Wpf.Client.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
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
        public MainWindow()
        {
            InitializeComponent();           

            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).Loaded();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.IsVisible == false) return;

            MessageBoxResult result = MessageBoxHelper.ShowSure("确定要退出系统?", this);
            if (result != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                (DataContext as MainWindowViewModel).Dispose();
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

    }
}
