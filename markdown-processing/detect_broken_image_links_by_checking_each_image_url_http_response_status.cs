// Detect broken image links by checking each image URL's HTTP response status.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with images
            string htmlContent = "<html><body>" +
                                 "<img src='https://www.example.com/valid-image.jpg' />" +
                                 "<img src='http://nonexistent.invalid/broken-image.jpg' />" +
                                 "</body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // List to store broken links
            List<string> brokenLinks = new List<string>();

            // Iterate over all link elements (including images with href/src if present)
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve relative URLs against the document's base URI
                string resolvedUrl = new Uri(new Uri(document.BaseURI), href).ToString();

                // Send a request to check the link
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(resolvedUrl);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl);
                }
            }

            // Output results
            if (brokenLinks.Count == 0)
            {
                Console.WriteLine("No broken links detected.");
            }
            else
            {
                Console.WriteLine("Broken links found:");
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