// Extract all hyperlink URLs from the Markdown document and store them in a list.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = @"
# Sample Document

This is a [link to Google](https://www.google.com) and another [link to GitHub](https://github.com).

Visit the [Aspose website](https://www.aspose.com) for more info.
";

            // Convert markdown links to HTML anchor tags
            string htmlContent = Regex.Replace(markdown, @"\[(?<text>.*?)\]\((?<url>.*?)\)", "<a href=\"$2\">$1</a>");

            // Load HTML content into Aspose.Html.HTMLDocument
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                List<string> hyperlinkUrls = new List<string>();

                foreach (Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        hyperlinkUrls.Add(href);
                    }
                }

                // Output extracted URLs
                Console.WriteLine("Extracted hyperlink URLs:");
                foreach (string url in hyperlinkUrls)
                {
                    Console.WriteLine(url);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}