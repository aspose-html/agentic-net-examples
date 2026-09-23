// Programmatically download each extracted resource efficiently using Aspose.HTML network utilities.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the page to process
            string pageUrl = "https://example.com";

            // Output directory for downloaded resources
            string outputDir = "DownloadedResources";
            Directory.CreateDirectory(outputDir);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(pageUrl))
            {
                // Process images
                HTMLCollection images = document.GetElementsByTagName("img");
                DownloadResources(document, images, "src", outputDir);

                // Process scripts
                HTMLCollection scripts = document.GetElementsByTagName("script");
                DownloadResources(document, scripts, "src", outputDir);

                // Process stylesheets (link elements with rel='stylesheet')
                HTMLCollection links = document.GetElementsByTagName("link");
                foreach (Element link in links)
                {
                    string rel = link.GetAttribute("rel");
                    if (!string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    DownloadResource(document, href, outputDir);
                }
            }

            Console.WriteLine("Resource download completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DownloadResources(HTMLDocument document, HTMLCollection collection, string attributeName, string outputDir)
    {
        for (int i = 0; i < collection.Length; i++)
        {
            Element element = (Element)collection[i];
            string url = element.GetAttribute(attributeName);
            if (string.IsNullOrEmpty(url))
                continue;

            DownloadResource(document, url, outputDir);
        }
    }

    private static void DownloadResource(HTMLDocument document, string resourceUrlString, string outputDir)
    {
        // Resolve relative URLs against the document's base URI
        Url resourceUrl = new Url(resourceUrlString, document.BaseURI);
        RequestMessage request = new RequestMessage(resourceUrl);
        ResponseMessage response = document.Context.Network.Send(request);

        if (!response.IsSuccess)
        {
            Console.WriteLine($"Failed to download: {resourceUrl}");
            return;
        }

        byte[] contentBytes = response.Content.ReadAsByteArray();
        string fileName = Path.GetFileName(resourceUrl.ToString());
        if (string.IsNullOrEmpty(fileName))
            fileName = Guid.NewGuid().ToString();

        string savePath = Path.Combine(outputDir, fileName);
        File.WriteAllBytes(savePath, contentBytes);
        Console.WriteLine($"Saved: {savePath}");
    }
}