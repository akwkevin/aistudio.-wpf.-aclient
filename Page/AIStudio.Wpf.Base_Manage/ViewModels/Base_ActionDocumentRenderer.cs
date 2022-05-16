using AIStudio.Core.Helpers;
using AIStudio.Wpf.BasePage.DTOModels;
using AIStudio.Wpf.Entity.DTOModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using AIStudio.Wpf.Controls;

namespace AIStudio.Wpf.Base_Manage.ViewModels
{
    class Base_ActionDocumentRenderer : IDocumentRenderer
    {
        public void Render(FlowDocument doc, object data)
        {
            if (data is ObservableCollection<IBaseTreeItemViewModel> items)
            {
                TableRowGroup groupDetails = doc.FindName("rowsDetails") as TableRowGroup;

                Style styleCell = doc.Resources["BorderedCell"] as Style;
                foreach (var item in items.OfType<Base_ActionTree>())
                {
                    TableRow row = new TableRow();
                    TableCell cell;
                    cell = new TableCell(new Paragraph(new Run(item.Text)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.TypeText)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Url)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.NeedActionText)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Value)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Icon)));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);

                    cell = new TableCell(new Paragraph(new Run(item.Sort.ToString())));
                    cell.Style = styleCell;
                    row.Cells.Add(cell);


                    groupDetails.Rows.Add(row);
                }
            }
        }
    }
}
