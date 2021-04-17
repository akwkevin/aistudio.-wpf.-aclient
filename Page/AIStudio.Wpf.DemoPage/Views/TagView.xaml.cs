using System.Windows.Controls;
using Util.Controls.Handy;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// TagView.xaml 的交互逻辑
    /// </summary>
    public partial class TagView : UserControl
    {
        public TagView()
        {
            InitializeComponent();
        }

        private void TagPanel_OnAddTagButtonClick(object sender, System.EventArgs e)
        {
            if (sender is TagPanel panel)
            {
                panel.Children.Add(new Tag
                {
                    Content = "SubTitle"
                });
            }
        }
    }
}
