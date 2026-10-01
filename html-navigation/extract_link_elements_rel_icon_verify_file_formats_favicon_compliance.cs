// Extract all link elements with rel="icon" and verify their file formats for favicon compliance.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with icon links
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<link rel=\"icon\" href=\"favicon.ico\" />" +
                                 "<link rel=\"icon\" href=\"icon.png\" />" +
                                 "<link rel=\"stylesheet\" href=\"style.css\" />" +
                                 "</head><body></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Iterate over all link elements and process those with rel=\"icon\"
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string rel = linkElement.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel) || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve the URL relative to the document's base URI
                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);

                // Send a request to fetch the icon resource
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(resolvedUrl);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Determine if the request succeeded
                bool isSuccess = response.IsSuccess;

                // Verify file format (favicon compliance)
                string urlString = resolvedUrl.ToString();
                string extension = Path.GetExtension(urlString).ToLowerInvariant();
                bool isCompliantFormat = extension == ".ico" || extension == ".png" || extension == ".svg";

                Console.WriteLine($"Icon href: {urlString}");
                Console.WriteLine($"  Request status: {(isSuccess ? "Success" : "Failed")}");
                Console.WriteLine($"  File extension: {extension}");
                Console.WriteLine($"  Compliant format: {isCompliantFormat}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}