// Extract all data‑table rows and calculate the sum of numeric columns for reporting.

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>
                <table>
                    <tr><td>10</td><td>abc</td></tr>
                    <tr><td>20</td><td>30</td></tr>
                </table>
                </body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                double sum = 0;
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
                foreach (var tableNode in tables)
                {
                    if (tableNode is Aspose.Html.HTMLTableElement table)
                    {
                        Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                        foreach (var rowNode in rows)
                        {
                            if (rowNode is Aspose.Html.HTMLTableRowElement row)
                            {
                                Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                                foreach (var cell in cells)
                                {
                                    string cellText = cell.TextContent?.Trim();
                                    if (double.TryParse(cellText, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                                    {
                                        sum += value;
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine(sum.ToString(CultureInfo.InvariantCulture));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}