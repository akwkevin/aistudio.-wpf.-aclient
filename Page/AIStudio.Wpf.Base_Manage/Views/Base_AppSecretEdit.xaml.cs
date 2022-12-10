using AIStudio.Wpf.Base_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_AppSecretEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_AppSecretEdit : ChildWindow
    {
        public Base_AppSecretEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
