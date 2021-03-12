using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// SvgIconView.xaml 的交互逻辑
    /// </summary>
    public partial class SvgIconView : UserControl
    {
        public SvgIconView()
        {
            InitializeComponent();
        }


        private void TextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.Dispatcher.BeginInvoke(new Action(textBox.SelectAll));
        }

        private void Search_OnKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (e.Key == Key.Enter)
                SearchButton.Command.Execute(textBox.Text);
        }
    }
}
