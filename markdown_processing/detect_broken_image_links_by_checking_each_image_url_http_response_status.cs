// Detect broken image links by checking each image URL's HTTP response status.

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
            // Load the HTML document from a file path
            string htmlPath = "sample.html";
            HTMLDocument document = new HTMLDocument(htmlPath);

            // List to store URLs of broken images
            List<string> brokenLinks = new List<string>();

            // Iterate over all <img> elements in the document
            foreach (Element imgElement in document.Images)
            {
                // Get the src attribute value
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve the URL against the document's base URI
                Url resolvedUrl = new Url(src, document.BaseURI);

                // Send a GET request to the resolved URL
                RequestMessage request = new RequestMessage(resolvedUrl);
                ResponseMessage response = document.Context.Network.Send(request);

                // If the response status code indicates an error, record the URL
                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl.ToString());
                }
            }

            // Output the broken image links
            Console.WriteLine("Broken image links:");
            foreach (var link in brokenLinks)
            {
                Console.WriteLine(link);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}