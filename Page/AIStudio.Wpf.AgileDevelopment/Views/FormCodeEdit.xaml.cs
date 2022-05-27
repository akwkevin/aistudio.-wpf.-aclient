using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.AgileDevelopment.Views
{
    /// <summary>
    /// FormCodeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class FormCodeEdit : BaseDialog
    {
        public FormCodeEdit(object viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
