using AIStudio.Wpf.Base_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_CommonFormConfigEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_CommonFormConfigEdit : BaseDialog
    {
        public Base_CommonFormConfigEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
