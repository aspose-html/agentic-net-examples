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
            string htmlContent = "<html><body>" +
                                 "<a href='page2.html'>Next</a> " +
                                 "<a href='page0.html'>Previous</a> " +
                                 "<a href='home.html'>Home</a>" +
                                 "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                List<string> paginationLinks = new List<string>();

                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string text = linkElement.TextContent != null ? linkElement.TextContent.Trim() : string.Empty;
                    if (string.IsNullOrEmpty(text))
                        continue;

                    if (text.IndexOf("next", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        text.IndexOf("previous", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string href = linkElement.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            paginationLinks.Add($"{text}: {href}");
                        }
                    }
                }

                Console.WriteLine("Pagination links found:");
                foreach (string item in paginationLinks)
                {
                    Console.WriteLine(item);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}