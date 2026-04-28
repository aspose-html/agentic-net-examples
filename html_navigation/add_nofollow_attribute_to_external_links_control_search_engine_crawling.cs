// Add a nofollow attribute to external links to control search engine crawling.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            var document = new HTMLDocument("https://example.com");
            foreach (Element link in document.Links)
            {
                string href = link.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;
                if (href.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    link.SetAttribute("rel", "nofollow");
                }
            }
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}