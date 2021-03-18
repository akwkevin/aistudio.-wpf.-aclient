using AIStudio.Wpf.Base_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_UserLogEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_UserLogEdit : BaseDialog
    {
        public Base_UserLogEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
