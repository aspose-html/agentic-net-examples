// Create an HTML document, add a table with colspan and rowspan attributes, and save as HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body></body></html>";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.HTMLElement body = doc.Body;
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)doc.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            body.AppendChild(table);

            // First row
            Aspose.Html.HTMLTableRowElement row0 = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
            Aspose.Html.HTMLTableCellElement cell00 = (Aspose.Html.HTMLTableCellElement)row0.InsertCell(row0.Cells.Length);
            cell00.TextContent = "Cell 1";
            cell00.SetAttribute("colspan", "2");
            Aspose.Html.HTMLTableCellElement cell01 = (Aspose.Html.HTMLTableCellElement)row0.InsertCell(row0.Cells.Length);
            cell01.TextContent = "Cell 3";

            // Second row
            Aspose.Html.HTMLTableRowElement row1 = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
            Aspose.Html.HTMLTableCellElement cell10 = (Aspose.Html.HTMLTableCellElement)row1.InsertCell(row1.Cells.Length);
            cell10.TextContent = "Cell 4";
            cell10.SetAttribute("rowspan", "2");
            Aspose.Html.HTMLTableCellElement cell11 = (Aspose.Html.HTMLTableCellElement)row1.InsertCell(row1.Cells.Length);
            cell11.TextContent = "Cell 5";
            Aspose.Html.HTMLTableCellElement cell12 = (Aspose.Html.HTMLTableCellElement)row1.InsertCell(row1.Cells.Length);
            cell12.TextContent = "Cell 6";

            // Third row
            Aspose.Html.HTMLTableRowElement row2 = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
            Aspose.Html.HTMLTableCellElement cell21 = (Aspose.Html.HTMLTableCellElement)row2.InsertCell(row2.Cells.Length);
            cell21.TextContent = "Cell 7";
            Aspose.Html.HTMLTableCellElement cell22 = (Aspose.Html.HTMLTableCellElement)row2.InsertCell(row2.Cells.Length);
            cell22.TextContent = "Cell 8";

            doc.Save(outputPath);
            Console.WriteLine("HTML file saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}