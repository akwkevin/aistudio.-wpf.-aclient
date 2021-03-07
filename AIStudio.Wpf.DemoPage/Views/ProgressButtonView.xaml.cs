using AIStudio.Wpf.DemoPage.ViewModels;
using System.Windows.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// ProgressButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressButtonView : UserControl
    {
        public ProgressButtonView()
        {
            InitializeComponent();
        }

        private void ButtonProgress_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.DataContext as ProgressButtonViewModel).ButtonProgress_OnClick(sender, e);
        }
    }
}
