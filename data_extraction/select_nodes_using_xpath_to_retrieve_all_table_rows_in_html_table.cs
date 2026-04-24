// Use Document.SelectNodes with an XPath query to retrieve all table rows in an HTML table.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            var document = new HTMLDocument("sample.html");
            HTMLCollection tables = document.GetElementsByTagName("table");
            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    HTMLCollection rows = table.GetElementsByTagName("tr");
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            Console.WriteLine("Row found with {0} cells.", row.Cells.Length);
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