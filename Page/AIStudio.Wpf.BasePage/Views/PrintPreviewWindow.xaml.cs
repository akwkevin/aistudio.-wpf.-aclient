using AIStudio.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AIStudio.Wpf.BasePage.Views
{
    /// <summary>
    /// PrintPreviewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PrintPreviewWindow : Window
    {
        public PrintPreviewWindow()
        {
            InitializeComponent();
        }

        public static FlowDocument LoadDocumentAndRender(string strTmplName, Object data, IDocumentRenderer renderer = null)
        {
            FlowDocument doc = (FlowDocument)Application.LoadComponent(new Uri(strTmplName, UriKind.RelativeOrAbsolute));
            doc.PagePadding = new Thickness(50);
            doc.DataContext = data;
            if (renderer != null)
            {
                renderer.Render(doc, data);
            }

            DocumentPaginator paginator = ((IDocumentPaginatorSource)doc).DocumentPaginator;
            paginator.PageSize = new Size(595, 842);
            //doc.PagePadding = new Thickness(50, 50, 50, 50);
            doc.ColumnWidth = double.PositiveInfinity;
            return doc;
        }
        public PrintPreviewWindow(string strTmplName, Object data, IDocumentRenderer renderer = null) : this()
        {
            if (data is System.Collections.IList resultList)
            {
                var m_doclist = new List<FlowDocument>();
                foreach (var result in resultList)
                {
                    m_doclist.Add(LoadDocumentAndRender(strTmplName, result, renderer));
                }
                Dispatcher.BeginInvoke(new PrintHelper.LoadManyXpsMethod(PrintHelper.LoadManyXps), DispatcherPriority.ApplicationIdle, m_doclist, docViewer);
            }
            else
            {
                var m_doc = LoadDocumentAndRender(strTmplName, data, renderer);
                Dispatcher.BeginInvoke(new PrintHelper.LoadXpsMethod(PrintHelper.LoadXps), DispatcherPriority.ApplicationIdle, m_doc, docViewer);
            }

        }

        public PrintPreviewWindow(string strTmplName, System.Collections.IList data, IDocumentRenderer renderer = null) : this()
        {
            var m_doc = LoadDocumentAndRender(strTmplName, data, renderer);
            Dispatcher.BeginInvoke(new PrintHelper.LoadXpsMethod(PrintHelper.LoadXps), DispatcherPriority.ApplicationIdle, m_doc, docViewer);
        }
    }
}
