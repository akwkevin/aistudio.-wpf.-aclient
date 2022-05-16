using AIStudio.Wpf.OA_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.OA_Manage.Views
{
    /// <summary>
    /// OA_DefFormEdit.xaml 的交互逻辑
    /// </summary>
    public partial class OA_DefFormTreeEdit : BaseDialog
    {
        public OA_DefFormTreeEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
