using AIStudio.Wpf.Base_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_RoleEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_RoleEdit : BaseDialog
    {
        public Base_RoleEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
