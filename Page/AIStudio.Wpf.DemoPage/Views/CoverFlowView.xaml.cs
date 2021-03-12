using System;
using System.Windows.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// CoverFlowView.xaml 的交互逻辑
    /// </summary>
    public partial class CoverFlowView : UserControl
    {
        public CoverFlowView()
        {
            InitializeComponent();

            CoverFlowMain.AddRange(new[]
            {
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/1.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/2.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/3.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/4.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/5.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/6.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/7.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/8.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/9.jpg"),
                new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Resources/Img/Album/10.jpg")
            });
            CoverFlowMain.JumpTo(2);
        }
    }
}
