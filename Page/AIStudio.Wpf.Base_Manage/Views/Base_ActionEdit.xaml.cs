using AIStudio.Wpf.Base_Manage.ViewModels;
using Prism.Mvvm;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.Views
{
    /// <summary>
    /// Base_ActionEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Base_ActionEdit : BaseDialog
    {
        public Base_ActionEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
