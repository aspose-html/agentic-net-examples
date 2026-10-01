// Extract all data‑table rows and calculate the sum of numeric columns for reporting.

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><table><tr><th>Item</th><th>Price</th></tr><tr><td>Apple</td><td>1.5</td></tr><tr><td>Banana</td><td>2.0</td></tr></table></body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");

            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

            double sum = 0;

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

            System.Console.WriteLine(sum.ToString(CultureInfo.InvariantCulture));
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}