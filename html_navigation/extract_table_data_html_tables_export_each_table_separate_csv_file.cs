// Extract table data from HTML tables and export each table to a separate CSV file.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the HTML page containing tables
            string url = args.Length > 0 ? args[0] : "https://example.com/page-with-tables.html";

            // Load the HTML document from the specified URL
            HTMLDocument document = new HTMLDocument(url);

            // Retrieve all <table> elements in the document
            HTMLCollection tables = document.GetElementsByTagName("table");

            int tableIndex = 0;
            // Iterate through each table
            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    StringBuilder csvBuilder = new StringBuilder();

                    // Get all rows (<tr>) of the current table
                    HTMLCollection rows = table.GetElementsByTagName("tr");

                    // Iterate through each row
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            // Get all cells of the current row
                            HTMLCollection cells = row.Cells;
                            bool firstCell = true;

                            // Iterate through each cell
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim() ?? string.Empty;

                                // Escape double quotes by doubling them
                                cellText = cellText.Replace("\"", "\"\"");

                                // Enclose the cell text in quotes if it contains commas or quotes
                                if (cellText.Contains(",") || cellText.Contains("\""))
                                {
                                    cellText = $"\"{cellText}\"";
                                }

                                if (!firstCell)
                                    csvBuilder.Append(',');

                                csvBuilder.Append(cellText);
                                firstCell = false;
                            }
                            csvBuilder.AppendLine();
                        }
                    }

                    // Write the CSV content to a file named table{index}.csv
                    string outputPath = $"table{tableIndex}.csv";
                    File.WriteAllText(outputPath, csvBuilder.ToString(), Encoding.UTF8);
                    Console.WriteLine($"Table {tableIndex} exported to {outputPath}");
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