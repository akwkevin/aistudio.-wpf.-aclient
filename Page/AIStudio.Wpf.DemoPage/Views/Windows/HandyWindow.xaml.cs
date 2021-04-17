using System;
using System.ComponentModel;

namespace AIStudio.Wpf.DemoPage.Views
{
    public partial class HandyMainWindow : Util.Controls.Handy.Windows.Window
    {
        public HandyMainWindow()
        {
            InitializeComponent();

            this.DataContext = new HandyWindowViewModel();

        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_interClose == true)
                return;

            _interClose = false;

            if (Util.Controls.Handy.Windows.MessageBoxWindow.YesNo("AppClosingTip", "Tip") != System.Windows.MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void OnCopy(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string)
            {
                var stringValue = e.Parameter as string;
                try
                {
                    System.Windows.Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
            }
        }

        private bool _interClose = false;

        public new void Close()
        {
            _interClose = true;
            this.Close();
        }
    }
}