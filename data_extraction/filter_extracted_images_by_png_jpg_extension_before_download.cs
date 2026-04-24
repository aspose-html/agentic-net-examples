// Filter extracted images by file extension, such as .png or .jpg, before download.

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
            // Load the HTML document from a URL
            HTMLDocument document = new HTMLDocument("https://example.com");

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Directory to save filtered images
            string outputDir = "downloaded_images";
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    // Cast collection item to Element
                    Element imgElement = (Element)images[i];

                    // Get the src attribute
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve to absolute URL
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Filter by file extension
                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Download the image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Save the image to disk
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}