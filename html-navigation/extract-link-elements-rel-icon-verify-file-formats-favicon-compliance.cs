// Extract all link elements with rel="icon" and verify their file formats for favicon compliance.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<link rel=\"icon\" href=\"favicon.ico\">" +
                                 "<link rel=\"icon\" href=\"logo.png\">" +
                                 "<link rel=\"icon\" href=\"image.jpg\">" +
                                 "</head><body></body></html>";

            // Load HTML from string with a dummy base URI
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            List<string> invalidIcons = new List<string>();

            foreach (Element linkElement in document.Links)
            {
                string rel = linkElement.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel) || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve the URL against the document's base URI
                Url resolvedUrl = new Url(href, document.BaseURI);

                // Determine file extension
                string extension = Path.GetExtension(resolvedUrl.ToString()).ToLowerInvariant();

                bool isValid = extension == ".ico" || extension == ".png" || extension == ".svg";

                Console.WriteLine($"Icon: {resolvedUrl} - {(isValid ? "Valid" : "Invalid")}");

                if (!isValid)
                {
                    invalidIcons.Add(resolvedUrl.ToString());
                }
            }

            if (invalidIcons.Count > 0)
            {
                Console.WriteLine("\nInvalid favicon links found:");
                foreach (string url in invalidIcons)
                {
                    Console.WriteLine(url);
                }
            }
            else
            {
                Console.WriteLine("\nAll favicon links are compliant.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}