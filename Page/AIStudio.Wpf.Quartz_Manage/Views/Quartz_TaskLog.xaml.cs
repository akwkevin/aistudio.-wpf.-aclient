using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Quartz_Manage.ViewModels;


namespace AIStudio.Wpf.Quartz_Manage.Views
{
    /// <summary>
    /// Quartz_TaskLog.xaml 的交互逻辑
    /// </summary>
    public partial class Quartz_TaskLog : BaseDialog
    {
        public Quartz_TaskLog(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
