// Filter extracted images by file extension, such as .png or .jpg, before download.

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
            // Sample HTML content with images
            string htmlContent = "<html><body>" +
                                 "<img src=\"https://example.com/image1.png\" />" +
                                 "<img src=\"https://example.com/photo.jpg\" />" +
                                 "<img src=\"https://example.com/graphic.svg\" />" +
                                 "</body></html>";

            // Create HTML document from content
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Output directory for downloaded images
            string outputDir = "DownloadedImages";
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
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}