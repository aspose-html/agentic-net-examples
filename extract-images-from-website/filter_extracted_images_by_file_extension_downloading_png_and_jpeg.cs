// Filter extracted images by file extension, downloading only PNG and JPEG formats.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with image references
            string htmlContent = @"
                <html>
                    <body>
                        <img src='https://example.com/images/sample1.png' />
                        <img src='https://example.com/images/sample2.jpg' />
                        <img src='https://example.com/images/sample3.gif' />
                    </body>
                </html>";

            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, ".");

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Output directory
            string outputDir = "ExtractedImages";
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve absolute URL
                    Uri baseUri = new Uri(document.BaseURI ?? "http://localhost/");
                    Uri imageUri = new Uri(baseUri, src);
                    string urlString = imageUri.ToString();

                    // Filter by extension
                    string extension = Path.GetExtension(urlString);
                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    // Download image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Save to file
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }

            Console.WriteLine("Image extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}