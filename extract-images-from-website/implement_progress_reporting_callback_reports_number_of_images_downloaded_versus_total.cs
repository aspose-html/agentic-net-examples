// Implement progress reporting callback that reports number of images downloaded versus total.

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
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src='https://example.com/image1.png' />
    <img src='https://example.com/image2.jpg' />
</body>
</html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Output directory for downloaded images
            string outputDir = "downloaded_images";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                int total = images.Length;
                int downloaded = 0;

                using (HttpClient httpClient = new HttpClient())
                {
                    for (int i = 0; i < total; i++)
                    {
                        Element imgElement = (Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                            continue;

                        // Resolve relative URLs against the document base URI
                        Url imageUrl = new Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();

                        // Download image bytes
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                        // Save to file
                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);

                        downloaded++;
                        Console.WriteLine($"Downloaded {downloaded}/{total} images - {fileName}");
                    }
                }
            }

            Console.WriteLine("Image download completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}