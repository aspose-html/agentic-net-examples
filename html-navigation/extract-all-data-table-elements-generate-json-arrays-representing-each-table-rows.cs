// Extract all data‑table elements and generate JSON arrays representing each table’s rows.

using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>" +
                          "<table><tr><td>R1C1</td><td>R1C2</td></tr>" +
                          "<tr><td>R2C1</td><td>R2C2</td></tr></table>" +
                          "<table><tr><td>A</td></tr></table>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
                for (int t = 0; t < tables.Length; t++)
                {
                    var tableNode = tables[t];
                    if (tableNode is Aspose.Html.HTMLTableElement table)
                    {
                        var tableData = new List<List<string>>();
                        Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                        for (int r = 0; r < rows.Length; r++)
                        {
                            var rowNode = rows[r];
                            if (rowNode is Aspose.Html.HTMLTableRowElement row)
                            {
                                var rowData = new List<string>();
                                Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                                for (int c = 0; c < cells.Length; c++)
                                {
                                    var cell = cells[c];
                                    string cellText = cell.TextContent?.Trim();
                                    rowData.Add(cellText ?? string.Empty);
                                }
                                tableData.Add(rowData);
                            }
                        }
                        string json = JsonSerializer.Serialize(tableData, new JsonSerializerOptions { WriteIndented = true });
                        Console.WriteLine($"Table {t} JSON:");
                        Console.WriteLine(json);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}