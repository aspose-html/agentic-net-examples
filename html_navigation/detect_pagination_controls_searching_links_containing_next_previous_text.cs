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
            string url = "https://example.com"; // replace with target URL
            using (HTMLDocument document = new HTMLDocument(url))
            {
                List<string> paginationLinks = new List<string>();
                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    string text = linkElement.TextContent != null ? linkElement.TextContent.Trim() : string.Empty;
                    if (text.IndexOf("next", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        text.IndexOf("previous", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        paginationLinks.Add($"{text}: {href}");
                    }
                }

                foreach (var item in paginationLinks)
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