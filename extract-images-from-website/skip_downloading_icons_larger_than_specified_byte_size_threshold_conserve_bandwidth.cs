// Skip downloading icons larger than a specified byte size threshold to conserve bandwidth.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output directory
            string htmlPath = "sample.html";
            string outputDir = "downloaded_icons";
            const long maxSizeBytes = 100 * 1024; // 100 KB threshold

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = @"<html><body>
<img src='https://via.placeholder.com/50.png' />
<img src='https://via.placeholder.com/200.png' />
</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve relative URLs against the document base URI
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Filter supported image extensions
                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".ico", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    // Download the image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Skip saving if the image exceeds the size threshold
                    if (imageBytes.Length > maxSizeBytes)
                    {
                        Console.WriteLine($"Skipped downloading large icon: {urlString} ({imageBytes.Length} bytes)");
                        continue;
                    }

                    // Save the image to the output directory
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                    Console.WriteLine($"Downloaded and saved: {savePath} ({imageBytes.Length} bytes)");
                }
            }

            // Cleanup
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}