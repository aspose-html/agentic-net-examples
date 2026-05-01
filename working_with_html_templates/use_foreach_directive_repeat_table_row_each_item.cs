// Use a foreach directive {{#foreach item in collection}} to repeat a table row for each item.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            HTMLDocument document = new HTMLDocument();

            // Get the body element
            HTMLElement body = document.Body;

            // Create a table element
            HTMLTableElement table = (HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("width", "50");

            // Append the table to the body
            body.AppendChild(table);

            // Sample collection to repeat rows for
            List<string> items = new List<string> { "Row 1", "Row 2", "Row 3" };

            // Repeat a table row for each item in the collection
            foreach (var item in items)
            {
                HTMLTableRowElement row = (HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                HTMLTableCellElement cell = (HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                cell.TextContent = item;
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}