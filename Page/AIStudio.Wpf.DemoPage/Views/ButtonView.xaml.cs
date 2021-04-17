using System;
using System.Windows.Controls;
using Util.Controls.Xceed;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// ButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonView : UserControl
    {
        public ButtonView()
        {
            InitializeComponent();
        }

        private void ButtonSpinner_Spin(object sender, Util.Controls.Xceed.SpinEventArgs e)
        {
            String[] names = (String[])this.Resources["names"];

            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = Array.IndexOf(names, txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;

            if (value < 0)
                value = names.Length - 1;
            else if (value >= names.Length)
                value = 0;

            txtBox.Text = names[value];
        }
    }
}
