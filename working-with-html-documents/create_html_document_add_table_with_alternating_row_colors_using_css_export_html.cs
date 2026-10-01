// Create an HTML document, add a table with alternating row colors using CSS, and export to HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML document from a string
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get the body element
            var body = (Aspose.Html.HTMLElement)document.Body;

            // Create a table element
            var table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.SetAttribute("border", "1");
            table.SetAttribute("align", "center");

            // Append the table to the body
            body.AppendChild(table);

            // Populate the table with rows and cells
            int rows = 3;
            int cols = 4;
            for (int i = 0; i < rows; i++)
            {
                var row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < cols; j++)
                {
                    var cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"R{i + 1}C{j + 1}";
                }
            }

            // Save the document to a file
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}