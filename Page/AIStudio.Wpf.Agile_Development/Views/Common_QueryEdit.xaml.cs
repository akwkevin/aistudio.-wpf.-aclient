using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Agile_Development.Views
{
    /// <summary>
    /// Base_UserQueryEdit.xaml 的交互逻辑
    /// </summary>
    public partial class Common_QueryEdit : ChildWindow
    {
        public Common_QueryEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
