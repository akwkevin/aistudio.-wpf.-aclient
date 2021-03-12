using System.Windows;
using System.Windows.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// NotifyIconView.xaml 的交互逻辑
    /// </summary>
    public partial class NotifyIconView : UserControl
    {
        public NotifyIconView()
        {
            InitializeComponent();
        }

        private void ButtonPush_OnClick(object sender, RoutedEventArgs e) => NotifyIconContextContent.CloseContextControl();
    }
}
