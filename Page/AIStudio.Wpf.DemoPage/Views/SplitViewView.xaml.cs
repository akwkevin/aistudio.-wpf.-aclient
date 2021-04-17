using System.Windows.Controls;
using Util.Controls;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// SplitViewView.xaml 的交互逻辑
    /// </summary>
    public partial class SplitViewView : UserControl
    {
        public SplitViewView()
        {
            InitializeComponent();
            this.SimpleSplitview.Tag = false;
        }

        private void Splitview_PaneClosing(object sender, SplitViewPaneClosingEventArgs e)
        {
            var splitView = sender as SplitView;

            if (splitView == null)
                return;

            e.Cancel = (bool)splitView.Tag;
        }
    }
}
