using AIStudio.Wpf.D_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.D_Manage.Views
{
    /// <summary>
    /// D_UserMessageEdit.xaml 的交互逻辑
    /// </summary>
    public partial class D_UserGroupEdit : BaseDialog
    {
        public D_UserGroupEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
