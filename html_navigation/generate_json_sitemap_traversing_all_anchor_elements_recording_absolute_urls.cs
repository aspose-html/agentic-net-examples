// Generate a JSON sitemap by traversing all anchor elements and recording their absolute URLs.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the page to process
            string url = "https://example.com";

            // Load the HTML document from the specified URL
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);

            // Collection of all anchor elements in the document
            var links = document.Links;

            // List to hold absolute URLs
            var sitemap = new List<string>();

            // Iterate over the collection and extract href attributes
            for (int i = 0; i < links.Length; i++)
            {
                // Cast each item to a generic DOM element
                var element = links[i] as Aspose.Html.Dom.Element;
                if (element == null) continue;

                // Get the href attribute value
                string href = element.GetAttribute("href");
                if (string.IsNullOrEmpty(href)) continue;

                // Resolve relative URLs to absolute using the document's base URI
                var absoluteUrl = new Url(href, document.BaseURI);
                sitemap.Add(absoluteUrl.ToString());
            }

            // Serialize the list of URLs to formatted JSON
            string json = JsonSerializer.Serialize(sitemap, new JsonSerializerOptions { WriteIndented = true });

            // Output the JSON sitemap
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            // Report any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}