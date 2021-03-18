using AIStudio.Wpf.Home.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Util.Controls;

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

            MenuControl.AddHandler(MenuItem.MouseUpEvent, new RoutedEventHandler(OnMouseUp), true);

            this.Loaded += MainView_Loaded;
        }

        private MainViewModel MainViewModel { get { return (DataContext as MainViewModel); } }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            //捕获得焦点，快捷键不好用，但是还有些问题，快捷键事件放到主窗体好了
            //Keyboard.Focus(this);
        }

        /// <summary>
        /// 左侧菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseUp(object sender, RoutedEventArgs e)
        {
            var menu = sender as Menu;
            MenuItem menuItem = null;

            if (e.Source is MenuItem)
            {
                menuItem = e.Source as MenuItem;
            }
            else
            {
                menuItem = GetItemFromChild(menu, e.OriginalSource as UIElement);
            }

            if (menuItem != null)
            {
                HamburgerMenuControl.SelectedItem = menuItem.DataContext;
            }
        }

        private static MenuItem GetItemFromChild(Menu treeView, UIElement child)
        {
            try
            {
                UIElement target = child;

                while ((target != null) && !(target is MenuItem))
                    target = System.Windows.Media.VisualTreeHelper.GetParent(target) as UIElement;

                return target as MenuItem;
            }
            catch
            {
                return null;
            }
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
