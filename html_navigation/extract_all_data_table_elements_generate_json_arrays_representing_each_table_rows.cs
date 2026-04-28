// Extract all data‑table elements and generate JSON arrays representing each table’s rows.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/page.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
            var allTablesJson = new List<string>();
            foreach (var tableNode in tables)
            {
                if (tableNode is Aspose.Html.HTMLTableElement table)
                {
                    var rowsArray = new List<List<string>>();
                    Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is Aspose.Html.HTMLTableRowElement row)
                        {
                            var cellsArray = new List<string>();
                            Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim();
                                cellsArray.Add(cellText);
                            }
                            rowsArray.Add(cellsArray);
                        }
                    }
                    string json = JsonSerializer.Serialize(rowsArray);
                    allTablesJson.Add(json);
                }
            }
            for (int i = 0; i < allTablesJson.Count; i++)
            {
                Console.WriteLine($"Table {i}: {allTablesJson[i]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}