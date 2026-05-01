// Create an HTML document, add a table with alternating row colors using CSS, and export to HTML.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing (or empty) HTML file to create a document
            var document = new Aspose.Html.HTMLDocument("input.html");

            // Get reference to the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create a new table element
            var table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("width", "50%");

            // Add 3 rows and 4 columns
            for (int i = 0; i < 3; i++)
            {
                // Insert a new row
                var row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);

                // Apply alternating background color
                if (i % 2 == 0)
                {
                    row.SetAttribute("style", "background-color:#f2f2f2;");
                }

                for (int j = 0; j < 4; j++)
                {
                    // Insert a new cell
                    var cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"Row {i + 1} Col {j + 1}";
                }
            }

            // Append the table to the document body
            body.AppendChild(table);

            // Save the modified document as HTML
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}