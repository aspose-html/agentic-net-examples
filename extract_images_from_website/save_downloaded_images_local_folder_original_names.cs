// Save downloaded images to a specified local folder preserving original file names.

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
            // Source of the HTML document (URL or local file path)
            string htmlSource = "https://example.com";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlSource);

            // Retrieve all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Directory where images will be saved
            string outputDir = "DownloadedImages";
            Directory.CreateDirectory(outputDir);

            // HttpClient for downloading image data
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    // Cast each collection item to an Element
                    Element imgElement = (Element)images[i];

                    // Get the src attribute value
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve relative URLs against the document's base URI
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Filter by supported image extensions
                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Download the image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Preserve the original file name
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);

                    // Save the image to the local folder
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