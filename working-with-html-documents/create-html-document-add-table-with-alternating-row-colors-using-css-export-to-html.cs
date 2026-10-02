// Create an HTML document, add a table with alternating row colors using CSS, and export to HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document with a basic structure
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Add CSS for alternating row colors
            Aspose.Html.Dom.Element head = document.QuerySelector("head");
            Aspose.Html.HTMLElement styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.InnerHTML = "table tr:nth-child(even) {background-color:#f2f2f2;}";
            head.AppendChild(styleElement);

            // Create a table
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.SetAttribute("border", "1");
            table.SetAttribute("cellpadding", "5");
            Aspose.Html.Dom.Element body = document.QuerySelector("body");
            body.AppendChild(table);

            // Populate the table with rows and cells
            int rows = 5;
            int columns = 3;
            for (int i = 0; i < rows; i++)
            {
                Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < columns; j++)
                {
                    Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"Row {i + 1}, Cell {j + 1}";
                }
            }

            // Save the document to an HTML file
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}