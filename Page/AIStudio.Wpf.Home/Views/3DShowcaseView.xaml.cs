using AIStudio.Wpf.BasePage.Models;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using Util._3DWall.Wall;

namespace AIStudio.Wpf.Home.Views
{
    /// <summary>
    /// _3DShowcaseView.xaml 的交互逻辑
    /// </summary>
    public partial class _3DShowcaseView : UserControl
    {
        public _3DShowcaseView()
        {
            InitializeComponent();
            Loaded += _3DShowcaseView_Loaded;
        }


        void _3DShowcaseView_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= _3DShowcaseView_Loaded;

            _mainwall.ItemClick += _mainwall_ItemClick;
        }

        Popwindow Popwindow;
        void _mainwall_ItemClick(object sender, Util._3DWall.Wall.WallControl.ItemclickEventArg e)
        {
            Popwindow = new Popwindow();
            Popwindow.X = 500;
            Popwindow.Y = 240;
            //Popwindow.Content = (e.Data as _3DItemData).Content;
            _grid.Children.Add(Popwindow);
            _rec.Visibility = Visibility.Visible;
            _rec.MouseLeftButtonDown += _rec_MouseLeftButtonDown;

        }

        void _rec_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _rec.Visibility = Visibility.Collapsed;
            _rec.MouseLeftButtonDown -= _rec_MouseLeftButtonDown;;
            _grid.Children.Remove(Popwindow);
        }
    }
}
