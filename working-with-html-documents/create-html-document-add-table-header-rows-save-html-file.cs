// Create an HTML document, add a table with header and rows, and save as HTML file.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputPath = "output.html";

                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

                Aspose.Html.HTMLElement body = doc.Body;

                Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)doc.CreateElement("table");
                table.Border = "1";

                body.AppendChild(table);

                // Header row
                Aspose.Html.HTMLTableRowElement headerRow = (Aspose.Html.HTMLTableRowElement)table.InsertRow(0);
                for (int j = 0; j < 4; j++)
                {
                    Aspose.Html.HTMLTableCellElement headerCell = (Aspose.Html.HTMLTableCellElement)headerRow.InsertCell(headerRow.Cells.Length);
                    headerCell.TextContent = $"Header {j + 1}";
                }

                // Data rows
                for (int i = 0; i < 3; i++)
                {
                    Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                    for (int j = 0; j < 4; j++)
                    {
                        Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                        cell.TextContent = $"Row {i + 1} Col {j + 1}";
                    }
                }

                doc.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}