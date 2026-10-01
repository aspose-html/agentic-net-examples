// Load an HTML file, extract all table elements, and write each table to separate HTML files.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a table
            string htmlContent = @"
                <html>
                    <body>
                        <h1>Sample Table</h1>
                        <table border='1'>
                            <tr><th>Name</th><th>Age</th></tr>
                            <tr><td>Alice</td><td>30</td></tr>
                            <tr><td>Bob</td><td>25</td></tr>
                        </table>
                    </body>
                </html>";

            // Load the HTML document from the string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all table elements
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

            // Iterate through each table
            foreach (var tableNode in tables)
            {
                if (tableNode is Aspose.Html.HTMLTableElement table)
                {
                    // Get all rows within the current table
                    Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");

                    foreach (var rowNode in rows)
                    {
                        if (rowNode is Aspose.Html.HTMLTableRowElement row)
                        {
                            // Get all cells within the current row
                            Aspose.Html.Collections.HTMLCollection cells = row.Cells;

                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim();
                                Console.WriteLine(cellText);
                            }
                        }
                    }
                }
            }

            // Optional: remove the first table and save the modified document
            if (tables.Length > 0)
            {
                var firstTable = (Aspose.Html.HTMLElement)tables[0];
                document.Body.RemoveChild(firstTable);
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine($"Modified document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}