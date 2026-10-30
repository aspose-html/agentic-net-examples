// Extract table data from HTML tables and export each table to a separate CSV file.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML containing two tables
            string htmlContent = @"
                <html>
                <body>
                    <table>
                        <tr><td>Header1</td><td>Header2</td></tr>
                        <tr><td>Row1Col1</td><td>Row1Col2</td></tr>
                    </table>
                    <table>
                        <tr><td>A</td><td>B</td></tr>
                        <tr><td>C</td><td>D</td></tr>
                    </table>
                </body>
                </html>";

            // Load HTML from string (inline content)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all table elements
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

            int tableIndex = 1;
            foreach (var tableNode in tables)
            {
                if (tableNode is Aspose.Html.HTMLTableElement table)
                {
                    // Collect CSV lines for the current table
                    var csvBuilder = new StringBuilder();

                    Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is Aspose.Html.HTMLTableRowElement row)
                        {
                            Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                            bool firstCell = true;
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim();
                                // Escape double quotes in CSV
                                if (cellText != null)
                                    cellText = cellText.Replace("\"", "\"\"");

                                if (!firstCell)
                                    csvBuilder.Append(',');

                                // Enclose in quotes if needed
                                csvBuilder.Append('\"').Append(cellText ?? string.Empty).Append('\"');
                                firstCell = false;
                            }
                            csvBuilder.AppendLine();
                        }
                    }

                    // Write CSV to file
                    string csvFileName = $"table{tableIndex}.csv";
                    File.WriteAllText(csvFileName, csvBuilder.ToString());
                    Console.WriteLine($"Table {tableIndex} exported to {csvFileName}");
                    tableIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}