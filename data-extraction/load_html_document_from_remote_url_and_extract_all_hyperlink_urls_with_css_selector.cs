// Load an HTML document from a remote URL and extract all hyperlink URLs with a CSS selector.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Collections.NodeList links = document.QuerySelectorAll("a[href]");
            foreach (Aspose.Html.Dom.Element element in links)
            {
                string href = element.GetAttribute("href");
                Console.WriteLine(href);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}