using System.Windows;
using System.Windows.Controls;
using Util.Controls;
using Util.Controls.Data;
using Util.Controls.Tools;
using Util.Controls.Windows;
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
            Util.Controls.Windows.MessageBoxWindow.Show("GrowlAsk", "Title", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void ButtonCustomMessage_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Util.Controls.Windows.MessageBoxWindow.Show(new MessageBoxInfo
            {
                Message = "GrowlAsk",
                Caption = "Title",
                Button = MessageBoxButton.YesNo,
                IconBrushKey = ResourceToken.AccentBrush,
                IconKey = ResourceToken.AskGeometry,
                StyleKey = "MessageBoxCustom"
            });
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
