using AIStudio.Wpf.HomePage.ViewModels;
using System.Windows;
using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.HomePage.Views
{
    /// <summary>
    /// NoticeIconView.xaml 的交互逻辑
    /// </summary>
    public partial class NoticeIconView : UserControl
    {
        public NoticeIconView()
        {
            InitializeComponent();
        }

        private NoticeIconViewModel NoticeIconViewModel { get { return (DataContext as NoticeIconViewModel); } }

    }
}
