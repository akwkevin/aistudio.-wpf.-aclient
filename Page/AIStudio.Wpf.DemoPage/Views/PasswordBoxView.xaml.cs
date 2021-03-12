using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// PasswordBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordBoxView : UserControl
    {
        public PasswordBoxView()
        {
            InitializeComponent();
        }

        private void WatermarkPasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            var passwordBox = sender as WatermarkPasswordBox;
            if (passwordBox != null)
            {
                _passwordTextBlock.Text = passwordBox.Password;
            }
        }
    }
}
