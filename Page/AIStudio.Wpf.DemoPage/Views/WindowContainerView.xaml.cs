using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Util.Controls.Xceed;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// WindowContainerView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowContainerView : UserControl
    {
        public WindowContainerView()
        {
            InitializeComponent();

            ObservableCollection<ColorItem> alphaAvailableColors = new ObservableCollection<ColorItem>();
            foreach (ColorItem item in _modalBackgroundColorPicker.AvailableColors)
            {
                System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb((byte)100, item.Color.Value.R, item.Color.Value.G, item.Color.Value.B);
                alphaAvailableColors.Add(new ColorItem(color, item.Name));
            }
            _modalBackgroundColorPicker.AvailableColors = alphaAvailableColors;

            this.UpdateWindowsStyles(null, null);
        }

        #region Event Handler

        private void OnChildWindowCheckBoxClick(object sender, EventArgs e)
        {
            _childWindow.WindowState = Util.Controls.Xceed.ChildWindows.WindowState.Open;
        }

        private void OnModalChildWindowCheckBoxClick(object sender, EventArgs e)
        {
            _modalChildWindow.WindowState = Util.Controls.Xceed.ChildWindows.WindowState.Open;
        }

        private void OnMessageBoxCheckBoxChecked(object sender, EventArgs e)
        {
            _messageBox.ShowMessageBox();
        }

        private void OnMessageBoxCheckBoxUnchecked(object sender, EventArgs e)
        {
            _messageBox.Visibility = System.Windows.Visibility.Collapsed;
            _messageBoxCheckBox.IsChecked = false;
        }

        private void OnMessageBoxClose(object sender, EventArgs e)
        {
            _messageBoxCheckBox.IsChecked = false;
        }

        #endregion

        private const string StandardMsgBoxTitle = "Standard MessageBox";
        private const string StyledMsgBoxTitle = "Toolkit for WPF styled MessageBox";
        private const string StyleableWindowTitle = "Toolkit for WPF StyleableWindow";
        private const string StandardMsgBoxMessage = "The standard system MessageBox will always have this look. No styling is possible.";
        private const string StyledMsgBoxMessage = "The Toolkit MessageBox allows you to style it in order to integrate it into your application colors and styles.";
        private const string StyleableWindowContent = "This is a StyleableWindow that has the same functionality as a normal window.";
        private const string MessageBoxStyleKey = "messageBoxStyle";
        private const string WindowControlStyleKey = "windowControlStyle";
        private const string WindowButtonStyle = "FancyButtonStyle";
        private const string StyleableWindowMessage = "StyleableWindow is a standalone window that can be styled just like ChildWindow or MessageBox. This is a feature of the \"Plus\" version.";
        private void OnStyleableWindow_Click(object sender, RoutedEventArgs e)
        {
            var msgBox = new Util.Controls.Xceed.MessageBox();
            msgBox.DataContext = this.DataContext;
            msgBox.Text = StyleableWindowMessage;
            msgBox.Caption = StyledMsgBoxTitle;
            msgBox.Style = (_enableStyleCheckBox.IsChecked.GetValueOrDefault()) ? (Style)this.Resources[MessageBoxStyleKey] : null;
            msgBox.ShowDialog();

        }

        private void StandardMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(StandardMsgBoxMessage, StandardMsgBoxTitle);
        }

        private void StyledMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            var msgBox = new Util.Controls.Xceed.MessageBox();
            msgBox.DataContext = this.DataContext;
            msgBox.Text = StyledMsgBoxMessage;
            msgBox.Caption = StyledMsgBoxTitle;

            if (_enableStyleCheckBox.IsChecked.GetValueOrDefault())
            {
                msgBox.Style = (Style)this.Resources[MessageBoxStyleKey];
            }
            msgBox.ShowDialog();

            //Util.Controls.MessageBox.Show(StyledMsgBoxMessage, "询问", MessageBoxButton.YesNo, MessageBoxImage.Question,
            //    MessageBoxResult.Yes);
        }

        private void UpdateWindowsStyles(object sender, RoutedEventArgs e)
        {
            bool styled = _enableStyleCheckBox.IsChecked.GetValueOrDefault();
            if (styled)
            {
                _childWindow.Style = (Style)this.Resources[WindowControlStyleKey];
            }
            else
            {
                _childWindow.ClearValue(ChildWindow.StyleProperty);
            }

        }
    }
}
