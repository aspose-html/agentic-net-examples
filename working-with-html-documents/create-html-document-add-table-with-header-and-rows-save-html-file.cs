// Create an HTML document, add a table with header and rows, and save as HTML file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            var doc = new Aspose.Html.HTMLDocument();

            // Create a table element
            var table = (Aspose.Html.HTMLTableElement)doc.CreateElement("table");
            table.Border = "1";

            // Add header row
            var headerRow = (Aspose.Html.HTMLTableRowElement)table.InsertRow(0);
            string[] headers = { "Header 1", "Header 2", "Header 3", "Header 4" };
            foreach (var header in headers)
            {
                var cell = (Aspose.Html.HTMLTableCellElement)headerRow.InsertCell(headerRow.Cells.Length);
                cell.TextContent = header;
            }

            // Add data rows
            for (int i = 0; i < 3; i++)
            {
                var row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < 4; j++)
                {
                    var cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"Row {i + 1} Col {j + 1}";
                }
            }

            // Append the table to the document body
            doc.Body.AppendChild(table);

            // Save the document as an HTML file
            string outputPath = "output.html";
            doc.Save(outputPath);
            Console.WriteLine($"HTML file saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}