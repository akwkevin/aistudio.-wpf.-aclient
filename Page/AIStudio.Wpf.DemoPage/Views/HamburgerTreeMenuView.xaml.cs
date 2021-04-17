using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// HamburgerTreeMenuView.xaml 的交互逻辑
    /// </summary>
    public partial class HamburgerTreeMenuView : UserControl
    {
        public HamburgerTreeMenuView()
        {
            InitializeComponent();
        }

        private void HamburgerMenu_OnItemClick(object sender, ItemClickEventArgs e)
        {
            // instead using binding Content="{Binding RelativeSource={RelativeSource Self}, Mode=OneWay, Path=SelectedItem}"
            // we can do this
            //HamburgerMenuControl.Content = e.ClickedItem;

            // close the menu if a item was selected
            //if (this.HamburgerMenuControl.IsPaneOpen)
            //{
            //    this.HamburgerMenuControl.IsPaneOpen = false;
            //}
        }

        private void HamburgerMenu_OnOptionsItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as HamburgerTreeMenuItem;
            MessageBox.Show($"You clicked on {menuItem.Label} button");
        }
    }
}
