// Create an HTML document, add a table with header and rows, and save as HTML file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("width", "50%");
            body.AppendChild(table);
            Aspose.Html.HTMLTableRowElement headerRow = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
            for (int j = 0; j < 4; j++)
            {
                Aspose.Html.HTMLTableCellElement headerCell = (Aspose.Html.HTMLTableCellElement)headerRow.InsertCell(headerRow.Cells.Length);
                headerCell.TextContent = $"Header {j + 1}";
            }
            for (int i = 0; i < 3; i++)
            {
                Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < 4; j++)
                {
                    Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"Row {i + 1} Col {j + 1}";
                }
            }
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}