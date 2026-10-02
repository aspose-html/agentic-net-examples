// Extract table data from HTML tables and export each table to a separate CSV file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with two tables
            string htmlContent = "<html><body>" +
                                 "<table>" +
                                 "<tr><th>Name</th><th>Age</th></tr>" +
                                 "<tr><td>Alice</td><td>30</td></tr>" +
                                 "<tr><td>Bob</td><td>25</td></tr>" +
                                 "</table>" +
                                 "<table>" +
                                 "<tr><td>Item1</td><td>10</td></tr>" +
                                 "<tr><td>Item2</td><td>20</td></tr>" +
                                 "</table>" +
                                 "</body></html>";

            // Load HTML document from string (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all table elements
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

            int tableIndex = 1;
            foreach (var tableNode in tables)
            {
                if (tableNode is Aspose.Html.HTMLTableElement table)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    // Get all rows in the current table
                    Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is Aspose.Html.HTMLTableRowElement row)
                        {
                            Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                            bool firstCell = true;
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim() ?? "";
                                // Escape commas and double quotes for CSV
                                if (cellText.Contains("\"") || cellText.Contains(","))
                                {
                                    cellText = $"\"{cellText.Replace("\"", "\"\"")}\"";
                                }

                                if (!firstCell)
                                    sb.Append(",");

                                sb.Append(cellText);
                                firstCell = false;
                            }
                            sb.AppendLine();
                        }
                    }

                    string outputPath = $"Table_{tableIndex}.csv";
                    System.IO.File.WriteAllText(outputPath, sb.ToString());
                    System.Console.WriteLine($"Table {tableIndex} saved to {outputPath}");
                    tableIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}