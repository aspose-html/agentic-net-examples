// Download image data asynchronously with HttpClient for each resolved image URL resource.

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
            // Load the HTML document from a local file
            HTMLDocument document = new HTMLDocument("input.html");

            // Get all <img> elements in the document
            HTMLCollection images = document.GetElementsByTagName("img");

            // Directory where downloaded images will be saved
            string outputDir = "downloaded_images";
            Directory.CreateDirectory(outputDir);

            // HttpClient for downloading image data
            using (HttpClient httpClient = new HttpClient())
            {
                // Iterate through each image element
                for (int i = 0; i < images.Length; i++)
                {
                    // Cast the collection item to an Element
                    Element imgElement = (Element)images[i];

                    // Retrieve the src attribute value
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve the URL against the document's base URI
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Filter by supported image extensions
                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Download the image bytes synchronously
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Determine file name and save path
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);

                    // Write the image to disk
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}