using AIStudio.Wpf.Base_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_DatasourceEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_DatasourceEdit : BaseDialog
    {
        public Base_DatasourceEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
