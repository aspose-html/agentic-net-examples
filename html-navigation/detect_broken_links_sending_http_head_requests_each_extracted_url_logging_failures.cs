// Detect broken links by sending HTTP HEAD requests to each extracted URL and logging failures.

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
            // Sample HTML content with some valid and broken links
            string htmlContent = @"
                <html>
                    <head><title>Link Test</title></head>
                    <body>
                        <a href='https://www.example.com/'>Valid Link</a>
                        <a href='https://www.example.com/nonexistentpage.html'>Broken Link</a>
                        <a href='invalidurl'>Invalid URL</a>
                    </body>
                </html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // List to store broken links
            List<string> brokenLinks = new List<string>();

            // Iterate over all link elements in the document
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve URL (relative to document base URI if needed)
                string resolvedUrl = href;
                try
                {
                    // Attempt to resolve relative URLs using System.Uri
                    Uri baseUri = new Uri(document.BaseURI ?? "http://localhost/");
                    Uri absoluteUri = new Uri(baseUri, href);
                    resolvedUrl = absoluteUri.ToString();
                }
                catch
                {
                    // If resolution fails, keep original href
                }

                // Create and send a HEAD request
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(resolvedUrl);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Check for HTTP error status codes (400 and above)
                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl);
                }
            }

            // Output results
            Console.WriteLine("Broken links detected:");
            if (brokenLinks.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (string url in brokenLinks)
                {
                    Console.WriteLine(url);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}