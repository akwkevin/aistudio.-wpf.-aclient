using AIStudio.Wpf.DemoPage.Service;

namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class ProjectsView
    {
        public ProjectsView()
        {
            InitializeComponent();

            this.DataContext = new ItemsDisplayViewModel(DataService.GetProjectDataList);
        }
    }
}
