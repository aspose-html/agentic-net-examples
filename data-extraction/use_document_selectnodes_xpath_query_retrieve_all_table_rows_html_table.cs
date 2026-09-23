// Use Document.SelectNodes with an XPath query to retrieve all table rows in an HTML table.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file with a table
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sample Table</title></head>
<body>
<table>
    <tr><td>Row1Cell1</td><td>Row1Cell2</td></tr>
    <tr><td>Row2Cell1</td><td>Row2Cell2</td></tr>
</table>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all table elements
            HTMLCollection tables = document.GetElementsByTagName("table");
            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    // Get all rows within the table
                    HTMLCollection rows = table.GetElementsByTagName("tr");
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            // Iterate through cells and output text
                            HTMLCollection cells = row.Cells;
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim();
                                Console.WriteLine(cellText);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}