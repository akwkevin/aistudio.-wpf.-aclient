using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace AIStudio.Core.Helpers
{
    public class PrintHelper
    {
        public delegate void LoadManyXpsMethod(List<FlowDocument> m_doclist, DocumentViewer docViewer);
        public delegate void LoadXpsMethod(FlowDocument m_doclist, DocumentViewer docViewer);

        public static void LoadXps(FlowDocument m_doc, DocumentViewer docViewer)
        {
            //构造一个基于内存的xps document
            MemoryStream ms = new MemoryStream();
            Package package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
            Uri DocumentUri = new Uri("pack://InMemoryDocument.xps");
            PackageStore.RemovePackage(DocumentUri);
            PackageStore.AddPackage(DocumentUri, package);
            XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);

            //将flow document写入基于内存的xps document中去
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.Write(((IDocumentPaginatorSource)m_doc).DocumentPaginator);

            //获取这个基于内存的xps document的fixed document
            docViewer.Document = xpsDocument.GetFixedDocumentSequence();

            ms.Dispose();
            //关闭基于内存的xps document
            xpsDocument.Close();
        }

        public static void LoadManyXps(List<FlowDocument> m_doclist, DocumentViewer docViewer)
        {
            //------------------定义新文档的结构
            FixedDocumentSequence newFds = new FixedDocumentSequence();//创建一个新的文档

            for (int i = 0; i < m_doclist.Count; i++)
            {
                //构造一个基于内存的xps document
                MemoryStream ms = new MemoryStream();
                Package package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
                Uri DocumentUri = new Uri("pack://InMemoryDocument" + i.ToString() + ".xps");
                PackageStore.RemovePackage(DocumentUri);
                PackageStore.AddPackage(DocumentUri, package);
                XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);

                //将flow document写入基于内存的xps document中去
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                writer.Write(((IDocumentPaginatorSource)m_doclist[i]).DocumentPaginator);

                DocumentReference newDocRef = AddPage(xpsDocument);//加入第一个文件
                newFds.References.Add(newDocRef);

                ms.Dispose();
                //关闭基于内存的xps document
                xpsDocument.Close();
            }

            string newFile = "xpsShow.xps";
            File.Delete(newFile);
            //xps写入新文件
            XpsDocument NewXpsDocument = new XpsDocument("xpsShow.xps", System.IO.FileAccess.ReadWrite);
            XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(NewXpsDocument);
            xpsDocumentWriter.Write(newFds);

            //获取这个基于内存的xps document的fixed document
            docViewer.Document = NewXpsDocument.GetFixedDocumentSequence();  
            NewXpsDocument.Close();
        }

        public static DocumentReference AddPage(XpsDocument xpsDocument)
        {
            DocumentReference newDocRef = new DocumentReference();
            FixedDocument newFd = new FixedDocument();

            FixedDocumentSequence docSeq = xpsDocument.GetFixedDocumentSequence();

            foreach (DocumentReference docRef in docSeq.References)
            {
                FixedDocument fd = docRef.GetDocument(false);

                foreach (PageContent oldPC in fd.Pages)
                {
                    Uri uSource = oldPC.Source;//读取源地址
                    Uri uBase = (oldPC as IUriContext).BaseUri;//读取目标页面地址

                    PageContent newPageContent = new PageContent();
                    newPageContent.GetPageRoot(false);
                    newPageContent.Source = uSource;
                    (newPageContent as IUriContext).BaseUri = uBase;
                    newFd.Pages.Add(newPageContent);//将新文档追加到新的documentRefences中
                }
            }
            newDocRef.SetDocument(newFd);
            xpsDocument.Close();
            return newDocRef;
        }

        public static DocumentReference AddPage(string fileName)
        {
            DocumentReference newDocRef = new DocumentReference();
            FixedDocument newFd = new FixedDocument();

            XpsDocument xpsDocument = new XpsDocument(fileName, FileAccess.Read);
            FixedDocumentSequence docSeq = xpsDocument.GetFixedDocumentSequence();

            foreach (DocumentReference docRef in docSeq.References)
            {
                FixedDocument fd = docRef.GetDocument(false);

                foreach (PageContent oldPC in fd.Pages)
                {
                    Uri uSource = oldPC.Source;//读取源地址
                    Uri uBase = (oldPC as IUriContext).BaseUri;//读取目标页面地址

                    PageContent newPageContent = new PageContent();
                    newPageContent.GetPageRoot(false);
                    newPageContent.Source = uSource;
                    (newPageContent as IUriContext).BaseUri = uBase;
                    newFd.Pages.Add(newPageContent);//将新文档追加到新的documentRefences中
                }
            }
            newDocRef.SetDocument(newFd);
            xpsDocument.Close();
            return newDocRef;
        }
    }
}
