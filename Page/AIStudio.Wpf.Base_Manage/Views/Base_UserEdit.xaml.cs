using AIStudio.Wpf.Base_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_UserEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_UserEdit : BaseDialog
    {
        public Base_UserEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
