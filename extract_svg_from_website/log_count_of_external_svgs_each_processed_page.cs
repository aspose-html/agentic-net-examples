// Log the count of external SVGs found on each processed page.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string[] pageUrls = new string[]
            {
                "https://example.com/page1.html",
                "https://example.com/page2.html"
            };

            foreach (string pageUrl in pageUrls)
            {
                HTMLDocument document = new HTMLDocument(pageUrl);
                HTMLCollection svgs = document.GetElementsByTagName("svg");
                int svgCount = svgs.Length;
                Console.WriteLine($"Page: {pageUrl} - External SVG count: {svgCount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}