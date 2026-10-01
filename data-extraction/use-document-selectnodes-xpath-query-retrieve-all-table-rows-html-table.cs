// Use Document.SelectNodes with an XPath query to retrieve all table rows in an HTML table.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><table><tr><td>Cell1</td><td>Cell2</td></tr><tr><td>Cell3</td><td>Cell4</td></tr></table></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

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
                            foreach (var cellNode in cells)
                            {
                                if (cellNode is Aspose.Html.HTMLTableCellElement cell)
                                {
                                    string cellText = cell.TextContent?.Trim();
                                    Console.WriteLine(cellText);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}