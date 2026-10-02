// Enable automatic detection and correction of broken links during website‑to‑HTML conversion.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Source website URL and output HTML file path
            string sourceUrl = "https://example.com";
            string outputPath = "converted.html";

            // Load the website into an HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);

            // List to store detected broken links
            List<string> brokenLinks = new List<string>();

            // HttpClient for link validation
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve relative URLs against the document's base URI
                    Uri resolvedUri;
                    try
                    {
                        resolvedUri = new Uri(new Uri(document.BaseURI), href);
                    }
                    catch
                    {
                        brokenLinks.Add(href);
                        linkElement.SetAttribute("href", "#");
                        continue;
                    }

                    // Perform a HEAD request to check the link status
                    HttpResponseMessage response;
                    try
                    {
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, resolvedUri);
                        response = httpClient.SendAsync(request).Result;
                    }
                    catch
                    {
                        brokenLinks.Add(resolvedUri.ToString());
                        linkElement.SetAttribute("href", "#");
                        continue;
                    }

                    if ((int)response.StatusCode >= 400)
                    {
                        brokenLinks.Add(resolvedUri.ToString());
                        linkElement.SetAttribute("href", "#");
                    }
                }
            }

            // Save the corrected HTML document
            document.Save(outputPath, new Aspose.Html.Saving.HTMLSaveOptions());

            // Output summary
            Console.WriteLine($"Conversion completed. Fixed {brokenLinks.Count} broken link(s).");
            foreach (string link in brokenLinks)
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