// Use a foreach loop to generate table rows for each record in a JSON dataset.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file with a table
            string htmlContent = @"
                <html>
                <body>
                    <table>
                        <tr><td>Row1Col1</td><td>Row1Col2</td></tr>
                        <tr><td>Row2Col1</td><td>Row2Col2</td></tr>
                    </table>
                </body>
                </html>";
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get all table elements
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

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

                                foreach (var cellObj in cells)
                                {
                                    if (cellObj is Aspose.Html.HTMLTableCellElement cell)
                                    {
                                        string cellText = cell.TextContent?.Trim();
                                        Console.WriteLine(cellText);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Clean up temporary file
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}