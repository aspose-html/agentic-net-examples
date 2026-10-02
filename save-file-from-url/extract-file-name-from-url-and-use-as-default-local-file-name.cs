// Extract the file name from the URL and use it as the default local file name.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputUrl = "https://example.com/sample.html";
            string outputDir = "DownloadedImages";

            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                // Download HTML content
                string htmlContent = httpClient.GetStringAsync(inputUrl).GetAwaiter().GetResult();

                // Load HTML document with base URI
                using (HTMLDocument document = new HTMLDocument(htmlContent, inputUrl))
                {
                    // Get all <img> elements
                    HTMLCollection images = document.GetElementsByTagName("img");

                    for (int i = 0; i < images.Length; i++)
                    {
                        Element imgElement = (Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrWhiteSpace(src))
                            continue;

                        // Resolve image URL against document base URI
                        Url imageUrl = new Url(src, document.BaseURI);
                        string imageUrlString = imageUrl.ToString();

                        // Download image bytes
                        byte[] imageBytes = httpClient.GetByteArrayAsync(imageUrlString).GetAwaiter().GetResult();

                        // Extract file name from URL
                        string fileName = Path.GetFileName(imageUrlString);
                        if (string.IsNullOrEmpty(fileName))
                            fileName = $"image_{i}.bin";

                        // Save image to output directory
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }

            Console.WriteLine("Images downloaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}