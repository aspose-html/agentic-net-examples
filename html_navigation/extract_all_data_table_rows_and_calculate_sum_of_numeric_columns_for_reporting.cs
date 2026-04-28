// Extract all data‑table rows and calculate the sum of numeric columns for reporting.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace TableSumApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://example.com/page.html";
                HTMLDocument document = new HTMLDocument(url);
                HTMLCollection tables = document.GetElementsByTagName("table");
                foreach (var tableNode in tables)
                {
                    if (tableNode is Aspose.Html.HTMLTableElement table)
                    {
                        HTMLCollection rows = table.GetElementsByTagName("tr");
                        List<double> columnSums = null;
                        foreach (var rowNode in rows)
                        {
                            if (rowNode is Aspose.Html.HTMLTableRowElement row)
                            {
                                HTMLCollection cells = row.Cells;
                                int colIndex = 0;
                                foreach (var cell in cells)
                                {
                                    string cellText = cell.TextContent?.Trim();
                                    double value;
                                    if (double.TryParse(cellText, out value))
                                    {
                                        if (columnSums == null) columnSums = new List<double>();
                                        if (columnSums.Count <= colIndex) columnSums.Add(0);
                                        columnSums[colIndex] += value;
                                    }
                                    colIndex++;
                                }
                            }
                        }
                        if (columnSums != null)
                        {
                            Console.WriteLine("Table sums:");
                            for (int i = 0; i < columnSums.Count; i++)
                            {
                                Console.WriteLine($"Column {i + 1}: {columnSums[i]}");
                            }
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