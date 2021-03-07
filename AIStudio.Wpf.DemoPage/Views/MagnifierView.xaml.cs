using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;

namespace AIStudio.Wpf.DemoPage.Views
{
    /// <summary>
    /// MagnifierView.xaml 的交互逻辑
    /// </summary>
    public partial class MagnifierView : UserControl
    {
        public MagnifierView()
        {
            InitializeComponent();

            // Load and display the RTF file.
            Uri uri = new Uri(@"pack://application:,,,/AIStudio.Wpf.DemoPage;component/Views/Resources/SampleText.rtf");
            StreamResourceInfo info = Application.GetResourceStream(uri);
            using (StreamReader txtReader = new StreamReader(info.Stream))
            {
                _txtContent.Text = txtReader.ReadToEnd();
            }
        }
    }
}
