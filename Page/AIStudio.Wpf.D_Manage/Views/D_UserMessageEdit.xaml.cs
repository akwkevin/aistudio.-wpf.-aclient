using AIStudio.Wpf.Controls;
using System.Windows;

namespace AIStudio.Wpf.D_Manage.Views
{
    /// <summary>
    /// D_UserMessageEditView.xaml 的交互逻辑
    /// </summary>
    public partial class D_UserMessageEdit : WindowBase
    {
        public D_UserMessageEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
