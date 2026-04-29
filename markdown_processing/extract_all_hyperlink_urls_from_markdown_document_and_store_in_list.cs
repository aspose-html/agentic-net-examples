// Extract all hyperlink URLs from the Markdown document and store them in a list.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the Markdown file
            string markdownPath = "input.md";

            // Convert Markdown to HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // List to store extracted hyperlink URLs
            List<string> hyperlinkUrls = new List<string>();

            // Iterate over all link elements in the document
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    hyperlinkUrls.Add(href);
                }
            }

            // Output the extracted URLs
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