using AIStudio.Wpf.BasePage.Models;
using AIStudio.Wpf.Home.ViewModels;
using Dataforge.PrismAvalonExtensions.ViewModels;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
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
            SizeChanged += _3DShowcaseView_SizeChanged;
        }

        private void _3DShowcaseView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Popwindow != null)
            {
                Popwindow.Width = this.ActualWidth * 0.8;
                Popwindow.Height = this.ActualHeight * 0.8;
            }
        }

        void _3DShowcaseView_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= _3DShowcaseView_Loaded;

            _mainwall.ItemClick += _mainwall_ItemClick;
        }

        Popwindow Popwindow;
        void _mainwall_ItemClick(object sender, Util._3DWall.Wall.WallControl.ItemclickEventArg e)
        {
            if (Popwindow != null) return;

            Popwindow = new Popwindow();
            Popwindow.Background = Application.Current.Resources["MahApps.Brushes.ThemeBackground"] as Brush;
            Popwindow.Padding = new Thickness(10);
            Popwindow.VerticalAlignment = VerticalAlignment.Center;
            Popwindow.HorizontalAlignment = HorizontalAlignment.Center;
            Popwindow.Width = this.ActualWidth * 0.8;
            Popwindow.Height = this.ActualHeight * 0.8;
            Popwindow.Content = (this.DataContext as _3DShowcaseViewModel).InitControl((e.Data as _3DItemData).WpfCode);
            _grid.Children.Add(Popwindow);
            _rec.Visibility = Visibility.Visible;
            _rec.MouseLeftButtonDown += _rec_MouseLeftButtonDown;

        }

        void _rec_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _rec.Visibility = Visibility.Collapsed;
            _rec.MouseLeftButtonDown -= _rec_MouseLeftButtonDown; ;
            _grid.Children.Remove(Popwindow);
            Popwindow = null;
        }
    }
}
