using AIStudio.Wpf.D_Manage.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.D_Manage.Views
{
    /// <summary>
    /// D_NoticeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class D_NoticeEdit : BaseDialog
    {
        public D_NoticeEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
