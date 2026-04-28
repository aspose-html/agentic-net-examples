// Detect broken links by sending HTTP HEAD requests to each extracted URL and logging failures.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

namespace BrokenLinkDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the HTML document from a file or URL
                HTMLDocument document = new HTMLDocument("input.html");

                // List to store broken link URLs
                List<string> brokenLinks = new List<string>();

                // Iterate over all link elements in the document
                foreach (Element linkElement in document.Links)
                {
                    // Get the href attribute value
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the URL against the document's base URI
                    Url resolvedUrl = new Url(href, document.BaseURI);

                    // Send a request to the resolved URL
                    RequestMessage request = new RequestMessage(resolvedUrl);
                    ResponseMessage response = document.Context.Network.Send(request);

                    // If the response status code indicates an error, record the link
                    if ((int)response.StatusCode >= 400)
                    {
                        brokenLinks.Add(resolvedUrl.ToString());
                    }
                }

                // Output the broken links
                Console.WriteLine("Broken links found:");
                foreach (string url in brokenLinks)
                {
                    Console.WriteLine(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}