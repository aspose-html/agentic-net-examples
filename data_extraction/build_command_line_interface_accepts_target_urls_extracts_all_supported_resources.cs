// Build a command‑line interface that accepts target URLs and extracts all supported resources.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ensure at least one URL is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: app <url1> <url2> ...");
                return;
            }

            foreach (var targetUrl in args)
            {
                // Load the HTML document from the given URL
                HTMLDocument document = new HTMLDocument(targetUrl);

                // Retrieve all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Create an output folder specific to the host of the URL
                string hostFolder = new Uri(targetUrl).Host;
                string outputDir = Path.Combine("downloaded_images", hostFolder);
                Directory.CreateDirectory(outputDir);

                // Use HttpClient to download image binaries
                using (HttpClient httpClient = new HttpClient())
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        // Cast each node to an Element to access attributes
                        Element imgElement = (Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                            continue;

                        // Resolve relative URLs against the document's base URI
                        Url imageUrl = new Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();

                        // Filter by common image extensions
                        string extension = Path.GetExtension(urlString);
                        if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                            continue;

                        // Download the image data synchronously
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                        // Save the image to the output directory
                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}