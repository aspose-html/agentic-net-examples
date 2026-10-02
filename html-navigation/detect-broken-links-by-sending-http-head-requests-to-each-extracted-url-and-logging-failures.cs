// Detect broken links by sending HTTP HEAD requests to each extracted URL and logging failures.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with links
            string htmlContent = "<html><body>" +
                                 "<a href='https://example.com'>Valid Link</a>" +
                                 "<a href='https://nonexistent.example/404'>Broken Link</a>" +
                                 "</body></html>";

            // Load HTML document from string (using a dummy base URI)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            List<string> brokenLinks = new List<string>();

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs against the document's base URI
                string absoluteUrl;
                try
                {
                    absoluteUrl = new Uri(new Uri(document.BaseURI), href).AbsoluteUri;
                }
                catch
                {
                    // Skip malformed URLs
                    continue;
                }

                // Send HTTP HEAD request
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(absoluteUrl);
                var response = document.Context.Network.Send(request);

                // Consider status codes 400 and above as failures
                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(absoluteUrl);
                }
            }

            // Log results
            Console.WriteLine("Broken links detected:");
            foreach (string url in brokenLinks)
            {
                Console.WriteLine(url);
            }

            if (brokenLinks.Count == 0)
            {
                Console.WriteLine("No broken links found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}