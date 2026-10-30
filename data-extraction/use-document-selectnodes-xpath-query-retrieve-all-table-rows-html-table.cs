// Use Document.SelectNodes with an XPath query to retrieve all table rows in an HTML table.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><table><tr><td>Cell1</td><td>Cell2</td></tr><tr><td>Cell3</td><td>Cell4</td></tr></table></body></html>";
                var document = new Aspose.Html.HTMLDocument(html, "about:blank");
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
                                    System.Console.WriteLine(cellText);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}