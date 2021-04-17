using AIStudio.Wpf.DemoPage.Service;

namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class WebsitesView
    {
        public WebsitesView()
        {
            InitializeComponent();

            this.DataContext = new ItemsDisplayViewModel(DataService.GetWebsiteDataList);
        }
    }
}
