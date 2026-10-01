// Extract all hyperlink URLs from the Markdown document and store them in a list.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Document\nThis is a [link to Example](https://example.com) and another [Google link](https://google.com).";

            // Convert markdown links to HTML anchor tags
            string htmlBody = Regex.Replace(markdown, @"\[(.*?)\]\((.*?)\)", "<a href=\"$2\">$1</a>");

            // Wrap the body in minimal HTML structure
            string fullHtml = $"<html><body>{htmlBody}</body></html>";

            // Load HTML into Aspose.Html.HTMLDocument
            HTMLDocument document = new HTMLDocument(fullHtml, "");

            // Extract hyperlink URLs
            List<string> hyperlinkUrls = new List<string>();
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    hyperlinkUrls.Add(href);
                }
            }

            // Output the extracted URLs
            Console.WriteLine("Extracted hyperlink URLs:");
            foreach (string url in hyperlinkUrls)
            {
                Console.WriteLine(url);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}