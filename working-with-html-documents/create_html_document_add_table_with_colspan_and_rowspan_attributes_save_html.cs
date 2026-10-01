// Create an HTML document, add a table with colspan and rowspan attributes, and save as HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new HTML document with basic structure
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><head><title>Table Example</title></head><body></body></html>");

            // Get the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create a table element
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("style", "width:80%;");

            // Append the table to the body
            body.AppendChild(table);

            int rows = 3;
            int cols = 4;

            for (int i = 0; i < rows; i++)
            {
                Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < cols; j++)
                {
                    Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"Row {i + 1}, Col {j + 1}";
                }
            }

            // Save the document to a file
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}