// Filter extracted images by file extension, downloading only PNG and JPEG formats.

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
            string inputHtmlPath = "sample.html";
            string htmlContent = @"<html><body>" +
                                 @"<img src=""https://via.placeholder.com/150.png"" />" +
                                 @"<img src=""https://via.placeholder.com/150.jpg"" />" +
                                 @"<img src=""https://via.placeholder.com/150.gif"" />" +
                                 @"</body></html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Get all img elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Output directory for downloaded images
            string outputDir = "output_images";
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();
                    string extension = Path.GetExtension(urlString);

                    if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                        continue;

                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
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