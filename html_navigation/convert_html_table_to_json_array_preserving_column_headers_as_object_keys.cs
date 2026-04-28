// Convert an HTML table into a JSON array preserving column headers as object keys.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string jsonOutputPath = "output.json";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all table elements
            HTMLCollection tables = document.GetElementsByTagName("table");

            var allTablesData = new List<List<Dictionary<string, string>>>();

            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
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
                                string cellText = cell.TextContent?.Trim();
                                cellTexts.Add(cellText);
                            }

                            if (isFirstRow)
                            {
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

            // Serialize the first table's data to JSON (or all tables if needed)
            string json = JsonSerializer.Serialize(allTablesData.Count > 0 ? allTablesData[0] : new List<Dictionary<string, string>>(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonOutputPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}