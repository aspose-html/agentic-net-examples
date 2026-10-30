// Extract all link elements with rel="icon" and verify their file formats for favicon compliance.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<link rel=\"icon\" href=\"https://example.com/favicon.ico\" />" +
                                 "<link rel=\"icon\" href=\"https://example.com/favicon.png\" />" +
                                 "<link rel=\"icon\" href=\"https://example.com/favicon.bmp\" />" + // non‑compliant example
                                 "<link rel=\"stylesheet\" href=\"style.css\" />" +
                                 "</head><body></body></html>";

            // Load HTML from inline content; use a dummy base URI.
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string rel = linkElement.GetAttribute("rel");
                if (string.IsNullOrEmpty(rel) || !rel.Equals("icon", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve the URL against the document's base URI.
                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(href, document.BaseURI);

                // Verify file format based on extension.
                string extension = Path.GetExtension(resolvedUrl.ToString()).ToLowerInvariant();
                bool isCompliant = extension == ".ico" || extension == ".png" || extension == ".svg" || extension == ".gif";

                Console.WriteLine($"Icon href: {resolvedUrl} - {(isCompliant ? "Compliant" : "Non‑compliant")}");

                // Optional: check that the resource can be fetched successfully.
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(resolvedUrl);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                if ((int)response.StatusCode >= 400)
                {
                    Console.WriteLine($"  Failed to load (HTTP {(int)response.StatusCode})");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}