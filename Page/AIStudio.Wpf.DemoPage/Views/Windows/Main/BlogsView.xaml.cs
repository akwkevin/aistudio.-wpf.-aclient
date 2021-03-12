using AIStudio.Wpf.DemoPage.Service;

namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class BlogsView
    {
        public BlogsView()
        {
            InitializeComponent();
            this.DataContext = new ItemsDisplayViewModel(DataService.GetBlogDataList);
        }
    }
}
