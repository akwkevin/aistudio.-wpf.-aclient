using AIStudio.Wpf.DemoPage.Core;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Resources;

namespace AIStudio.Wpf.DemoPage.Controls
{
    public abstract class CodeBox : Util.Controls.Xceed.RichTextBoxs.RichTextBox
    {
        protected CodeBox()
        {
            this.IsReadOnly = true;
            this.FontFamily = new FontFamily("Courier New");
            this.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
            this.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
            this.Document.PageWidth = 2500;
        }

        public string CodeSource
        {
            set
            {
                if (value == null)
                    this.Text = null;

                this.Text = this.GetDataFromResource(value); 
            }
        }

        private string GetDataFromResource(string uriString)
        {
            Uri uri = new Uri(uriString, UriKind.RelativeOrAbsolute);
            StreamResourceInfo info = Application.GetResourceStream(uri);

            StreamReader reader = new StreamReader(info.Stream);
            string data = reader.ReadToEnd();
            reader.Close();

            return data;
        }

    }

    public class XamlBox : CodeBox
    {
        public XamlBox() { this.TextFormatter = new XamlFormatter(); }
    }

    public class CSharpBox : CodeBox
    {
        public CSharpBox() { this.TextFormatter = new CSharpFormatter(); }
    }
}
