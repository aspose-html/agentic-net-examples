// Use CancellationToken to allow graceful termination of the image extraction process.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
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
            // Create a cancellation token source to allow graceful termination
            using var cts = new CancellationTokenSource();

            // Cancel on Ctrl+C
            Console.CancelKeyPress += (sender, e) =>
            {
                cts.Cancel();
                e.Cancel = true;
            };

            // Path to the HTML file to process
            string htmlPath = "input.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Directory where downloaded images will be saved
            string outputDir = "DownloadedImages";
            Directory.CreateDirectory(outputDir);

            using HttpClient httpClient = new HttpClient();

            // Iterate through each image element
            for (int i = 0; i < images.Length; i++)
            {
                // Check for cancellation request
                if (cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Operation cancelled by user.");
                    break;
                }

                Element imgElement = (Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve the image URL relative to the document base URI
                Url imageUrl = new Url(src, document.BaseURI);
                string urlString = imageUrl.ToString();

                // Filter by supported extensions
                string extension = Path.GetExtension(urlString);
                if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Download the image bytes with cancellation support
                byte[] imageBytes = httpClient.GetByteArrayAsync(urlString, cts.Token)
                                             .GetAwaiter()
                                             .GetResult();

                // Save the image to the output directory
                string fileName = Path.GetFileName(urlString);
                string savePath = Path.Combine(outputDir, fileName);
                File.WriteAllBytes(savePath, imageBytes);
            }

            Console.WriteLine("Image extraction completed.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Image extraction was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}