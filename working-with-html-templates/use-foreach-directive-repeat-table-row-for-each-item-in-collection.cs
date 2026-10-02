// Use a foreach directive {{#foreach item in collection}} to repeat a table row for each item.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Sample data collection
            var items = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>();
            items.Add(new System.Collections.Generic.Dictionary<string, string>
            {
                { "href", "https://example.com/1" },
                { "text", "Example 1" }
            });
            items.Add(new System.Collections.Generic.Dictionary<string, string>
            {
                { "href", "https://example.com/2" },
                { "text", "Example 2" }
            });

            // HTML content with a placeholder table
            string htmlContent = "<html><body><table id='data'></table></body></html>";

            // Load the HTML document (inline content)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Retrieve the first table element
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
            Aspose.Html.HTMLTableElement table = null;
            if (tables.Length > 0)
            {
                table = tables[0] as Aspose.Html.HTMLTableElement;
            }

            if (table != null)
            {
                // Repeat a table row for each item in the collection
                foreach (var item in items)
                {
                    var row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                    var cellHref = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cellHref.TextContent = item["href"];
                    var cellText = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cellText.TextContent = item["text"];
                }
            }

            // Save the modified document to a file
            document.Save("output.html");
            System.Console.WriteLine("HTML file generated: output.html");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}