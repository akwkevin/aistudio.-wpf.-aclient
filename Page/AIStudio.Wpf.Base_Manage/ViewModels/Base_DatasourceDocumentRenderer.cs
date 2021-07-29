using AIStudio.Core.Helpers;
using AIStudio.Wpf.EFCore.DTOModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    class Base_DatasourceDocumentRenderer : IDocumentRenderer
    {
        public void Render(FlowDocument doc, object data)
        {
            if (data is ObservableCollection<Base_DatasourceDTO> items)
            {
                TableRowGroup groupDetails = doc.FindName("rowsDetails") as TableRowGroup;

                Style styleCell = doc.Resources["BorderedCell"] as Style;
                foreach (var item in items)
                {
                    TableRow row = new TableRow();
                    TableCell cell;
                    cell = new TableCell(new Paragraph(new Run(item.Code)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Name)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.DbLinkId)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Sql)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Description)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);


                    groupDetails.Rows.Add(row);
                }
            }
        }
    }
}
