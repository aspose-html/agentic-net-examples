// Detect pagination controls by searching for links containing “next” or “previous” text.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"
                <html>
                    <body>
                        <a href='page1.html'>Previous</a>
                        <a href='page2.html'>1</a>
                        <a href='page3.html'>2</a>
                        <a href='page4.html'>Next</a>
                        <a href='page5.html'>Last</a>
                    </body>
                </html>";

            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            List<Dictionary<string, string>> paginationLinks = new List<Dictionary<string, string>>();

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                string text = linkElement.TextContent != null ? linkElement.TextContent.Trim() : string.Empty;

                if (text.IndexOf("next", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    text.IndexOf("previous", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var item = new Dictionary<string, string>
                    {
                        { "href", href },
                        { "text", text }
                    };
                    paginationLinks.Add(item);
                }
            }

            Console.WriteLine("Detected pagination links:");
            foreach (var linkInfo in paginationLinks)
            {
                Console.WriteLine($"Text: {linkInfo["text"]}, Href: {linkInfo["href"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}