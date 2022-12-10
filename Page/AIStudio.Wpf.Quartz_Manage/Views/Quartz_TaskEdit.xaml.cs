using AIStudio.Wpf.Controls;
using AIStudio.Wpf.Quartz_Manage.ViewModels;

namespace AIStudio.Wpf.Quartz_Manage.Views
{
    /// <summary>
    /// Quartz_TaskEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Quartz_TaskEdit : ChildWindow
    {
        public Quartz_TaskEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
