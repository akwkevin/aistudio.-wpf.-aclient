using AIStudio.Wpf.Quartz_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.Quartz_Manage.Views
{
    /// <summary>
    /// Quartz_TaskEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Quartz_TaskEdit : BaseDialog
    {
        public Quartz_TaskEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
