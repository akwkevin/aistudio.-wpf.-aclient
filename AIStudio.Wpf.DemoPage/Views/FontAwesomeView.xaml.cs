using System.Windows.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// FontAwesomeView.xaml 的交互逻辑
    /// </summary>
    public partial class FontAwesomeView : UserControl
    {
        public FontAwesomeView()
        {
            InitializeComponent();
            webBrowser.Navigate("http://www.fontawesome.com.cn/cheatsheet/");
        }
    }
}
