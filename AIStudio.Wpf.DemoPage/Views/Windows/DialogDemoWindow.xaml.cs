namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class DialogDemoWindow
    {
        public DialogDemoWindow()
        {
            InitializeComponent();

            this.DataContext = new DialogDemoViewModel();
        }
    }
}
