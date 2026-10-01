// Extract all data‑table elements and generate JSON arrays representing each table’s rows.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ExtractTablesToJson
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = @"<html><body>" +
                    "<table><tr><td>Header1</td><td>Header2</td></tr>" +
                    "<tr><td>Row1Col1</td><td>Row1Col2</td></tr></table>" +
                    "<table><tr><td>A</td></tr><tr><td>B</td></tr></table>" +
                    "</body></html>";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
                {
                    Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
                    for (int t = 0; t < tables.Length; t++)
                    {
                        Aspose.Html.HTMLElement htmlTable = tables[t] as Aspose.Html.HTMLElement;
                        if (htmlTable is Aspose.Html.HTMLTableElement table)
                        {
                            Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                            var tableData = new List<List<string>>();
                            for (int r = 0; r < rows.Length; r++)
                            {
                                if (rows[r] is Aspose.Html.HTMLTableRowElement row)
                                {
                                    Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                                    var rowData = new List<string>();
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
                            Console.WriteLine($"Table {t + 1} JSON:");
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
}