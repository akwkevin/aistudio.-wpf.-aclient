using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// DropDownView.xaml 的交互逻辑
    /// </summary>
    public partial class DropDownView : UserControl
    {
        public DropDownView()
        {
            InitializeComponent();
        }

        private void DropDownButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _dropDownButton.IsOpen = false;
            _splitButton.IsOpen = false;
        }

        private void SplitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for clicking me!", "SplitButton Click");
        }
    }
}
