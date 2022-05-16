using AIStudio.Wpf.D_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.D_Manage.Views
{
    /// <summary>
    /// D_UserMailEdit.xaml 的交互逻辑
    /// </summary>
    public partial class D_UserMailEdit : BaseDialog
    {
        public D_UserMailEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
