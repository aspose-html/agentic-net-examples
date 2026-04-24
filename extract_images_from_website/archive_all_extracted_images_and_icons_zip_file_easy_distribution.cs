// Archive all extracted images and icons into a ZIP file for easy distribution.

using System;
using System.IO;
using System.IO.Compression;
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
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Directory where extracted images will be saved
            string outputDir = "extracted_images";
            Directory.CreateDirectory(outputDir);

            // Download images referenced in the HTML
            using (HttpClient httpClient = new HttpClient())
            {
                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Get all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                for (int i = 0; i < images.Length; i++)
                {
                    // Cast each element to a DOM element
                    Element imgElement = (Element)images[i];

                    // Retrieve the src attribute
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve relative URLs against the document base URI
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Filter by supported image extensions (png, jpg, jpeg, ico)
                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".ico", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Download the image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Save the image to the output directory
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }

            // Create a ZIP archive containing all extracted images
            string zipPath = "images.zip";
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(outputDir, zipPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}