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
            string html = @"<html><body>
                <table>
                    <tr><td>R1C1</td><td>R1C2</td></tr>
                    <tr><td>R2C1</td><td>R2C2</td></tr>
                </table>
                <table>
                    <tr><td>A</td></tr>
                </table>
            </body></html>";

            using (HTMLDocument document = new HTMLDocument(html, "about:blank"))
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                var tablesData = new List<List<List<string>>>();

                for (int t = 0; t < tables.Length; t++)
                {
                    var tableNode = tables[t];
                    if (tableNode is HTMLTableElement table)
                    {
                        HTMLCollection rows = table.GetElementsByTagName("tr");
                        var rowsData = new List<List<string>>();

                        for (int r = 0; r < rows.Length; r++)
                        {
                            var rowNode = rows[r];
                            if (rowNode is HTMLTableRowElement row)
                            {
                                HTMLCollection cells = row.Cells;
                                var cellValues = new List<string>();

                                for (int c = 0; c < cells.Length; c++)
                                {
                                    var cell = cells[c];
                                    string text = cell.TextContent?.Trim();
                                    cellValues.Add(text ?? string.Empty);
                                }

                                rowsData.Add(cellValues);
                            }
                        }

                        tablesData.Add(rowsData);
                    }
                }

                string json = JsonSerializer.Serialize(tablesData, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}