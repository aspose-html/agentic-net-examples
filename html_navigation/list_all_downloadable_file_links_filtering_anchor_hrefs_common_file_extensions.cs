// List all downloadable file links by filtering anchor hrefs with common file extensions.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL
            HTMLDocument document = new HTMLDocument("https://example.com/page.html");

            // List to store downloadable file links
            List<string> downloadableLinks = new List<string>();

            // Common file extensions to filter
            string[] extensions = new string[]
            {
                ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx",
                ".zip", ".rar", ".7z", ".tar.gz", ".txt", ".csv",
                ".jpg", ".jpeg", ".png", ".gif", ".bmp",
                ".mp3", ".wav", ".mp4", ".avi", ".mov", ".wmv"
            };

            // Iterate over all anchor elements in the document
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs to absolute URLs
                Url resolvedUrl = new Url(href, document.BaseURI);
                string urlString = resolvedUrl.ToString();

                // Check if the URL ends with any of the specified extensions
                foreach (string ext in extensions)
                {
                    if (urlString.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                    {
                        downloadableLinks.Add(urlString);
                        break;
                    }
                }
            }

            // Output the collected downloadable links
            Console.WriteLine("Downloadable file links found:");
            foreach (string link in downloadableLinks)
            {
                Console.WriteLine(link);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}