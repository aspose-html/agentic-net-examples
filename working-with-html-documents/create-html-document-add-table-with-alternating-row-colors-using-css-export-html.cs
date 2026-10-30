// Create an HTML document, add a table with alternating row colors using CSS, and export to HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlSkeleton = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlSkeleton, "about:blank");

            // Add CSS for alternating row colors
            Aspose.Html.Dom.Element head = document.QuerySelector("head");
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.TextContent = "table { border-collapse: collapse; width: 100%; } " +
                                "tr:nth-child(even) { background-color: #f2f2f2; } " +
                                "th, td { border: 1px solid #ddd; padding: 8px; }";
            head.AppendChild(style);

            // Create table
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.SetAttribute("border", "1");

            // Header row
            Aspose.Html.HTMLTableRowElement headerRow = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
            for (int j = 0; j < 3; j++)
            {
                Aspose.Html.HTMLTableCellElement th = (Aspose.Html.HTMLTableCellElement)headerRow.InsertCell(headerRow.Cells.Length);
                th.TextContent = $"Header {j + 1}";
            }

            // Data rows
            for (int i = 0; i < 5; i++)
            {
                Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < 3; j++)
                {
                    Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"R{i + 1}C{j + 1}";
                }
            }

            // Append table to body
            Aspose.Html.HTMLElement body = document.Body;
            body.AppendChild(table);

            // Save to HTML file
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}