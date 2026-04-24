// Load an HTML document from a remote URL and extract all hyperlink URLs with a CSS selector.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string address = "https://example.com";
            HTMLDocument document = new HTMLDocument(address);
            var nodes = document.QuerySelectorAll("a[href]");
            foreach (Element element in nodes)
            {
                string href = element.GetAttribute("href");
                Url absolute = new Url(href, document.BaseURI);
                Console.WriteLine(absolute);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}