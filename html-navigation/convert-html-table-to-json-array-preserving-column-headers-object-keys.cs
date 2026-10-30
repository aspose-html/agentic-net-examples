// Convert an HTML table into a JSON array preserving column headers as object keys.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing a table
            string htmlContent = "<html><body>" +
                                 "<table>" +
                                 "<tr><th>Name</th><th>Age</th><th>City</th></tr>" +
                                 "<tr><td>Alice</td><td>30</td><td>New York</td></tr>" +
                                 "<tr><td>Bob</td><td>25</td><td>London</td></tr>" +
                                 "<tr><td>Charlie</td><td>35</td><td>Sydney</td></tr>" +
                                 "</table>" +
                                 "</body></html>";

            // Load HTML document from inline content
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all tables in the document
            HTMLCollection tables = document.GetElementsByTagName("table");

            var allTablesData = new List<List<Dictionary<string, string>>>();

            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    // Get all rows in the current table
                    HTMLCollection rows = table.GetElementsByTagName("tr");
                    var headers = new List<string>();
                    var tableData = new List<Dictionary<string, string>>();
                    bool isFirstRow = true;

                    foreach (var rowNode in rows)
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            HTMLCollection cells = row.Cells;
                            var cellTexts = new List<string>();

                            foreach (var cell in cells)
                            {
                                string text = cell.TextContent?.Trim() ?? string.Empty;
                                cellTexts.Add(text);
                            }

                            if (isFirstRow)
                            {
                                // First row assumed to be header
                                headers.AddRange(cellTexts);
                                isFirstRow = false;
                            }
                            else
                            {
                                var rowDict = new Dictionary<string, string>();
                                for (int i = 0; i < headers.Count && i < cellTexts.Count; i++)
                                {
                                    rowDict[headers[i]] = cellTexts[i];
                                }
                                tableData.Add(rowDict);
                            }
                        }
                    }

                    allTablesData.Add(tableData);
                }
            }

            // Serialize each table's data to JSON and write to separate files
            for (int i = 0; i < allTablesData.Count; i++)
            {
                string json = JsonSerializer.Serialize(allTablesData[i], new JsonSerializerOptions { WriteIndented = true });
                string outputPath = $"table_{i + 1}.json";
                File.WriteAllText(outputPath, json);
                Console.WriteLine($"Table {i + 1} JSON saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}