// Enable automatic detection and correction of broken links during website‑to‑HTML conversion.

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
            // Load the source HTML document
            string sourcePath = "input.html";
            HTMLDocument document = new HTMLDocument(sourcePath);

            // List to store detected broken links
            List<string> brokenLinks = new List<string>();

            // Iterate over all anchor and area elements with href attributes
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve the URL against the document's base URI
                Url resolvedUrl = new Url(href, document.BaseURI);

                // Send a request to check the link status
                RequestMessage request = new RequestMessage(resolvedUrl);
                ResponseMessage response = document.Context.Network.Send(request);

                // If the response indicates an error, record and correct the link
                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl.ToString());

                    // Simple correction: replace the broken href with a placeholder
                    linkElement.SetAttribute("href", "#");
                }
            }

            // Save the corrected HTML document
            string outputPath = "output.html";
            document.Save(outputPath);

            // Optionally, display the broken links that were found
            Console.WriteLine("Broken links detected and corrected:");
            foreach (string url in brokenLinks)
            {
                Console.WriteLine(url);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}