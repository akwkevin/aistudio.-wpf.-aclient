namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class InteractiveDialog
    {
        public InteractiveDialog()
        {
            InitializeComponent();

            this.DataContext = new InteractiveDialogViewModel();
        }
    }
}
