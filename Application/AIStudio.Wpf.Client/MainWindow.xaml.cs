using AIStudio.Wpf.BasePage.Events;
using AIStudio.Wpf.Business;
using AIStudio.Wpf.Client.ViewModels;
using AIStudio.Wpf.Client.Views;
using AIStudio.Wpf.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Input;

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

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.IsVisible == false) return;

            MessageBoxResult result = Controls.MessageBox.YesNo("确定要退出系统?", owner:this);
            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            else
            { 
                System.Windows.Application.Current.Shutdown();
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

    }
}
