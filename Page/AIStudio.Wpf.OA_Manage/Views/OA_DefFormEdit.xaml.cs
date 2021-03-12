using AIStudio.Wpf.OA_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.OA_Manage.Views
{
    /// <summary>
    /// OA_DefFormEdit.xaml 的交互逻辑
    /// </summary>
    public partial class OA_DefFormEdit : BaseDialog
    {
        public OA_DefFormEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
