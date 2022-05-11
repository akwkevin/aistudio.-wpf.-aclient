using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Util.Controls;

namespace ServiceMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Closing += MainWindow_Closing;
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
                System.Windows.Application.Current.Shutdown();
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

    }
}
