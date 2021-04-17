using AIStudio.Wpf.DemoPage.Models;
using System.Windows.Controls;
using Util.Controls.Xceed.RichTextBoxs;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// RichTextBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class RichTextBoxView : UserControl
    {
        public RichTextBoxView()
        {
            InitializeComponent();
        }

        private void OnTextFormatterChanged(object sender, SelectionChangedEventArgs args)
        {
            this.UpdateFormatter();
        }

        private void UpdateFormatter()
        {
            if ((_textFormatter != null) && (_text != null) && (_richTextBox != null))
            {
                object tagValue = ((ComboBoxItem)_textFormatter.SelectedItem).Tag;
                if (object.Equals(TextFormatterEnum.PlainText, tagValue))
                {
                    _richTextBox.TextFormatter = new PlainTextFormatter();
                }
                else if (object.Equals(TextFormatterEnum.Rtf, tagValue))
                {
                    _richTextBox.TextFormatter = new RtfFormatter();
                }
                else if (object.Equals(TextFormatterEnum.Xaml, tagValue))
                {
                    _richTextBox.TextFormatter = new XamlFormatter();
                }
            }
        }
    }
}
