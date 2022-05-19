using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.AgileDevelopment.Views
{
    /// <summary>
    /// Base_UserQueryEdit.xaml 的交互逻辑
    /// </summary>
    public partial class CommonQueryEdit : BaseDialog
    {
        public CommonQueryEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
