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
            // Define sample HTML with image references
            string htmlContent = "<html><body>" +
                                 "<img src='https://via.placeholder.com/150' />" +
                                 "<img src='https://via.placeholder.com/1024' />" +
                                 "</body></html>";

            // Prepare input and output paths
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "downloaded_images");
            Directory.CreateDirectory(outputDir);

            // Write sample HTML to file
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputHtmlPath))
            {
                // Get all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Size threshold in bytes (e.g., 100 KB)
                const long maxSizeBytes = 100 * 1024;

                using (HttpClient httpClient = new HttpClient())
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        Element imgElement = (Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                            continue;

                        // Resolve the image URL relative to the document base URI
                        Url imageUrl = new Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();

                        // Perform a HEAD request to check Content-Length
                        using (HttpRequestMessage headRequest = new HttpRequestMessage(HttpMethod.Head, urlString))
                        using (HttpResponseMessage headResponse = httpClient.Send(headRequest))
                        {
                            if (!headResponse.IsSuccessStatusCode)
                                continue;

                            long contentLength = headResponse.Content.Headers.ContentLength ?? -1;
                            if (contentLength > maxSizeBytes && contentLength != -1)
                            {
                                Console.WriteLine($"Skipping large image ({contentLength} bytes): {urlString}");
                                continue;
                            }
                        }

                        // Download the image
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
                        string fileName = Path.GetFileName(new Uri(urlString).LocalPath);
                        if (string.IsNullOrEmpty(fileName))
                            fileName = Guid.NewGuid().ToString() + ".img";

                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                        Console.WriteLine($"Saved image: {savePath}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}