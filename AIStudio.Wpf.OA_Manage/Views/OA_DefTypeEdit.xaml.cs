using AIStudio.Wpf.OA_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.OA_Manage.Views
{
    /// <summary>
    /// OA_DefTypeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class OA_DefTypeEdit : BaseDialog
    {
        public OA_DefTypeEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
