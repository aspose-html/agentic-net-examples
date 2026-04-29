// Validate that every URL in the document uses the HTTPS scheme for secure connections.

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
            // URL of the HTML document to validate
            string sourceUrl = "https://example.com";

            // Load the HTML document from the specified URL
            HTMLDocument document = new HTMLDocument(sourceUrl);

            // Iterate through all link elements in the document
            foreach (Element linkElement in document.Links)
            {
                // Get the href attribute value
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs against the document's base URI
                Url resolvedUrl = new Url(href, document.BaseURI);

                // Check if the URL uses HTTPS scheme
                if (!resolvedUrl.ToString().StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Non-HTTPS URL found: {resolvedUrl}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}