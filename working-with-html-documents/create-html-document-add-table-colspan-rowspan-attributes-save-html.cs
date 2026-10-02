// Create an HTML document, add a table with colspan and rowspan attributes, and save as HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document with a base URI.
            var document = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head><title>Table Example</title></head><body></body></html>", "about:blank");

            // Get the body element.
            Aspose.Html.HTMLElement body = document.Body;

            // Create a table element.
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";

            // Append the table to the body.
            body.AppendChild(table);

            // First row with a cell that spans two columns.
            Aspose.Html.HTMLTableRowElement row0 = (Aspose.Html.HTMLTableRowElement)table.InsertRow(0);
            Aspose.Html.HTMLTableCellElement cell00 = (Aspose.Html.HTMLTableCellElement)row0.InsertCell(0);
            cell00.TextContent = "Header";
            cell00.SetAttribute("colspan", "2");
            Aspose.Html.HTMLTableCellElement cell01 = (Aspose.Html.HTMLTableCellElement)row0.InsertCell(1);
            cell01.TextContent = "Extra";

            // Second row with a cell that spans two rows.
            Aspose.Html.HTMLTableRowElement row1 = (Aspose.Html.HTMLTableRowElement)table.InsertRow(1);
            Aspose.Html.HTMLTableCellElement cell10 = (Aspose.Html.HTMLTableCellElement)row1.InsertCell(0);
            cell10.TextContent = "Side";
            cell10.SetAttribute("rowspan", "2");
            Aspose.Html.HTMLTableCellElement cell11 = (Aspose.Html.HTMLTableCellElement)row1.InsertCell(1);
            cell11.TextContent = "R2C2";

            // Third row (the side cell continues spanning).
            Aspose.Html.HTMLTableRowElement row2 = (Aspose.Html.HTMLTableRowElement)table.InsertRow(2);
            Aspose.Html.HTMLTableCellElement cell20 = (Aspose.Html.HTMLTableCellElement)row2.InsertCell(0);
            cell20.TextContent = "R3C2";

            // Save the document to an HTML file.
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.html");
            document.Save(outputPath);

            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}