
using AIStudio.Wpf.DemoPage.Service;

namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class ContributorsView
    {
        public ContributorsView()
        {
            InitializeComponent();
            this.DataContext = new ItemsDisplayViewModel(DataService.GetContributorDataList);
        }
    }
}