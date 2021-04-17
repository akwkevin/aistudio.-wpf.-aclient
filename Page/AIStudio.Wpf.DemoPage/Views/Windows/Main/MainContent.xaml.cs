using System.Windows;
using Util.Controls.Handy.Tools.Extension;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    ///     主内容
    /// </summary>
    public partial class MainContent
    {
        private bool _isFull;

        public MainContent()
        {
            InitializeComponent();

            this.Loaded += MainContent_Loaded;

        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            var viewmodel = this.DataContext as HandyWindowViewModel;
            viewmodel.PropertyChanged += Viewmodel_PropertyChanged;
        }

        private void Viewmodel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsFull")
            {
                var viewmodel = sender as HandyWindowViewModel;
                FullSwitch(viewmodel.IsFull);
            }
        }

        private void FullSwitch(bool isFull)
        {
            if (_isFull == isFull) return;
            _isFull = isFull;
            if (_isFull)
            {
                BorderEffect.Collapse();
                BorderTitle.Collapse();
                GridMain.HorizontalAlignment = HorizontalAlignment.Stretch;
                GridMain.VerticalAlignment = VerticalAlignment.Stretch;
                GridMain.Margin = new Thickness();
                PresenterMain.Margin = new Thickness();
            }
            else
            {
                BorderEffect.Show();
                BorderTitle.Show();
                GridMain.HorizontalAlignment = HorizontalAlignment.Center;
                GridMain.VerticalAlignment = VerticalAlignment.Center;
                GridMain.Margin = new Thickness(16);
                PresenterMain.Margin = new Thickness(0, 0, 0, 10);
            }
        }

        private void DrawerCode_OnOpened(object sender, RoutedEventArgs e)
        {  
            if (PresenterMain.Content is FrameworkElement demoCtl)
            {
                var xamlPath = $"Views/{demoCtl.GetType().Name}.xaml";
                var dc = demoCtl.DataContext;
                var dcTypeName = dc.GetType().Name;
                var vmPath = $"ViewModels/{dcTypeName}";

                EditorXaml.Text = DemoHelper.GetCodeByFile(xamlPath);
                EditorCs.Text = DemoHelper.GetCodeByFile($"{xamlPath}.cs");
                EditorVm.Text = DemoHelper.GetCodeByFile($"{vmPath}.cs");
            }
        }
    }
}