using AIStudio.Wpf.Base_Manage.ViewModels;
using Util.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_UnitTestEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_UnitTestEdit : BaseDialog
    {
        public Base_UnitTestEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
