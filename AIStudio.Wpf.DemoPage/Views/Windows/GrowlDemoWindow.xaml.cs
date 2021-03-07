namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class GrowlDemoWindow
    {
        public GrowlDemoWindow()
        {
            InitializeComponent();

            this.DataContext = new GrowlDemoViewModel("GrowlDemoPanel");
        }
    }
}
