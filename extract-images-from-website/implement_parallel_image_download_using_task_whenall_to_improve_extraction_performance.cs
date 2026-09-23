// Implement parallel image download using Task.WhenAll to improve overall extraction performance.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            // Prepare sample HTML file with image references
            string inputHtmlPath = "sample.html";
            string htmlContent = "<html><body>" +
                                 "<img src=\"https://via.placeholder.com/150.jpg\"/>" +
                                 "<img src=\"https://via.placeholder.com/200.png\"/>" +
                                 "</body></html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Output directory for downloaded images
            string outputDir = "downloaded_images";
            Directory.CreateDirectory(outputDir);

            // HttpClient for downloading images
            using (HttpClient httpClient = new HttpClient())
            {
                List<Task> downloadTasks = new List<Task>();

                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();
                    string extension = Path.GetExtension(urlString);

                    if (!extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Create a task for each image download
                    Task downloadTask = Task.Run(async () =>
                    {
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(urlString);
                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        await File.WriteAllBytesAsync(savePath, imageBytes);
                    });

                    downloadTasks.Add(downloadTask);
                }

                // Wait for all downloads to complete
                Task.WhenAll(downloadTasks).GetAwaiter().GetResult();
            }

            Console.WriteLine("Image download completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}