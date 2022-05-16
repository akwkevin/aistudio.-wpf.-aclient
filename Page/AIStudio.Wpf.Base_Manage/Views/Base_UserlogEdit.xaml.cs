using AIStudio.Wpf.Base_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_UserEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_UserlogEdit : BaseDialog
    {
        public Base_UserlogEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
