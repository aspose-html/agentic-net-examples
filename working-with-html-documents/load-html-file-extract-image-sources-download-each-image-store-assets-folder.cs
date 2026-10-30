// Load an HTML file, extract all image sources, download each image, and store in assets folder.

using System;
using System.IO;
using System.Net.Http;
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
            // Input HTML file path
            string inputPath = "sample.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<html><body>" +
                    "<img src=\"https://via.placeholder.com/150\" />" +
                    "<img src=\"image2.png\" />" +
                    "</body></html>");
            }

            // Output directory for images
            string outputDir = "assets";
            Directory.CreateDirectory(outputDir);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (Aspose.Html.Dom.Element image in images)
                {
                    string src = image.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve the image URL against the document's base URI
                    Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Skip data URIs
                    if (urlString.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Download the image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Determine file name and save path
                    string fileName = Path.GetFileName(urlString);
                    if (string.IsNullOrEmpty(fileName))
                        fileName = Guid.NewGuid().ToString() + ".bin";

                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }

            Console.WriteLine("Images have been downloaded to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}