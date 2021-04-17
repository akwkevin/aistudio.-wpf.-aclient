using System.Windows;
using System.Windows.Controls;
using Util.Controls.Handy;
using Util.Controls.Handy.Data;
using Util.Controls.Handy.Tools;
using Util.Controls.Handy.Windows;
using WindowStartupLocation = System.Windows.WindowStartupLocation;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// NativeWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class NativeWindowView : UserControl
    {
        public NativeWindowView()
        {
            InitializeComponent();
        }

        private void ButtonMessage_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Util.Controls.MessageBox.Show("GrowlAsk", "Title", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void ButtonCustomMessage_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Util.Controls.MessageBox.Show("GrowlAsk", "Title", ResourceToken.AccentBrush, ResourceToken.AskGeometry);
        }

        private void ButtonMouseFollow_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var picker = SingleOpenHelper.CreateControl<ColorPicker_V1>();
            var window = new PopupWindow
            {
                PopupElement = picker
            };
            picker.SelectedColorChanged += delegate { window.Close(); };
            picker.Canceled += delegate { window.Close(); };
            window.Show(ButtonMouseFollow, false);
        }

        private void ButtonCustomContent_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var picker = SingleOpenHelper.CreateControl<ColorPicker_V1>();
            var window = new PopupWindow
            {
                PopupElement = picker,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                MinWidth = 0,
                MinHeight = 0,
                Title = "ColorPicker"
            };
            picker.SelectedColorChanged += delegate { window.Close(); };
            picker.Canceled += delegate { window.Close(); };
            window.Show();
        }
    }
}
