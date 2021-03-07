using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// GeometryAnimationView.xaml 的交互逻辑
    /// </summary>
    public partial class GeometryAnimationView : UserControl
    {
        public GeometryAnimationView()
        {
            InitializeComponent();

            BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/under_construction.gif"));

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = image;
            ib.ViewboxUnits = BrushMappingMode.RelativeToBoundingBox; //按百分比设置宽高
            ib.TileMode = TileMode.None; //按百分比应该不会出现 image小于要切的值的情况
            ib.Stretch = Stretch.None;
            path.Fill = ib;
        }

        
    }
}
