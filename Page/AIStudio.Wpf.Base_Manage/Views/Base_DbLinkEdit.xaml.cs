using AIStudio.Wpf.Base_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_DbLinkEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_DbLinkEdit : BaseDialog
    {
        public Base_DbLinkEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
