using AIStudio.Wpf.Home.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Home.Views
{
    /// <summary>
    /// MainContentRegion.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }


        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string)
            {
                var stringValue = e.Parameter as string;
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
            }
        }

    }
}
