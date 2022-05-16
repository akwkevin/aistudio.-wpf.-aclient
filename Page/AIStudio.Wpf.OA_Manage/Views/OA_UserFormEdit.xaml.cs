using AIStudio.Wpf.OA_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.OA_Manage.Views
{
    /// <summary>
    /// OA_UserFormEdit.xaml 的交互逻辑
    /// </summary>
    public partial class OA_UserFormEdit : BaseDialog
    {
        public OA_UserFormEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
