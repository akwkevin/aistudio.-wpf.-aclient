using AIStudio.Core.Helpers;
using AIStudio.Wpf.Business.DTOModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    class Base_AppSecretDocumentRenderer : IDocumentRenderer
    {
        public void Render(FlowDocument doc, object data)
        {
            if (data is ObservableCollection<Base_AppSecretDTO> items)
            {
                TableRowGroup groupDetails = doc.FindName("rowsDetails") as TableRowGroup;

                Style styleCell = doc.Resources["BorderedCell"] as Style;
                foreach (var item in items)
                {
                    TableRow row = new TableRow();
                    TableCell cell;
                    cell = new TableCell(new Paragraph(new Run(item.AppId)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.AppSecret)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.AppName)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);


                    groupDetails.Rows.Add(row);
                }
            }
        }
    }
}
