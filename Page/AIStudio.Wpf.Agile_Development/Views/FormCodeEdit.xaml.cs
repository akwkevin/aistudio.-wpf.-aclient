using AIStudio.Wpf.Agile_Development.ViewModels;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Agile_Development.Views
{
    /// <summary>
    /// FormCodeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class FormCodeEdit : BaseDialog
    {
        public FormCodeEdit(FormCodeEditViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;

            viewModel.RootGrid = RootGrid;
        }
    }
}
