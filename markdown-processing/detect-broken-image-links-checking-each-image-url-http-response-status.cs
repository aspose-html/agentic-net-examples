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
            // Sample HTML with image tags
            string htmlContent = "<html><body>" +
                                 "<img src='https://example.com/valid-image.jpg' />" +
                                 "<img src='https://example.com/missing-image.jpg' />" +
                                 "</body></html>";

            // Load HTML document (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            List<string> brokenLinks = new List<string>();

            // Iterate over all <img> elements
            foreach (Element imgElement in document.GetElementsByTagName("img"))
            {
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Create request for the image URL
                RequestMessage request = new RequestMessage(src);
                ResponseMessage response = document.Context.Network.Send(request);

                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(src);
                }
            }

            // Output results
            if (brokenLinks.Count == 0)
            {
                Console.WriteLine("No broken image links found.");
            }
            else
            {
                Console.WriteLine("Broken image links:");
                foreach (string url in brokenLinks)
                {
                    Console.WriteLine(url);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}