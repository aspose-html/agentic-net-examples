// Programmatically download each extracted resource efficiently using Aspose.HTML network utilities.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with two images
            string htmlContent = "<html><body>" +
                                 "<img src='https://via.placeholder.com/150' />" +
                                 "<img src='https://via.placeholder.com/100' />" +
                                 "</body></html>";

            // Load HTML document from string (base URI is required for relative URLs)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Prepare output directory
            string outputDir = "downloaded_resources";
            Directory.CreateDirectory(outputDir);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve absolute URL based on document's base URI
                Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);

                // Create request and send it using Aspose.HTML network utilities
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(absoluteUrl);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                if (!response.IsSuccess)
                    continue;

                // Read content bytes
                byte[] contentBytes = response.Content.ReadAsByteArray();

                // Determine file name and save path
                string fileName = Path.GetFileName(absoluteUrl.ToString());
                string savePath = Path.Combine(outputDir, fileName);

                // Write the downloaded resource to disk
                File.WriteAllBytes(savePath, contentBytes);
            }

            Console.WriteLine("Resources downloaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}