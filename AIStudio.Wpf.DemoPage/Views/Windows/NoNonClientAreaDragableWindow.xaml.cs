using System.Windows;

namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class NoNonClientAreaDragableWindow
    {
        public NoNonClientAreaDragableWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e) => Close();
    }
}
