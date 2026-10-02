// Implement parallel image download using Task.WhenAll to improve overall extraction performance.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Prepare sample HTML file with image tags
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src='https://via.placeholder.com/150.jpg' />
    <img src='https://via.placeholder.com/200.png' />
    <img src='https://via.placeholder.com/250.gif' />
    <img src='https://example.com/ignore.txt' />
</body>
</html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Output directory for downloaded images
            string outputDir = "Images";
            Directory.CreateDirectory(outputDir);

            // Prepare HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                List<Task> downloadTasks = new List<Task>();

                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve URL against document base URI
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);

                    // Create a download task
                    Task downloadTask = httpClient.GetByteArrayAsync(urlString).ContinueWith(t =>
                    {
                        if (t.Exception == null)
                        {
                            File.WriteAllBytes(savePath, t.Result);
                            Console.WriteLine($"Downloaded: {fileName}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to download {urlString}: {t.Exception.GetBaseException().Message}");
                        }
                    });

                    downloadTasks.Add(downloadTask);
                }

                // Wait for all downloads to complete
                await Task.WhenAll(downloadTasks);
            }

            Console.WriteLine("Image extraction completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}