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
            string htmlPath = "input.html";
            string outputDir = "downloaded_images";
            Directory.CreateDirectory(outputDir);
            HTMLDocument document = new HTMLDocument(htmlPath);
            HTMLCollection images = document.GetElementsByTagName("img");
            int total = 0;
            for (int i = 0; i < images.Length; i++)
            {
                Element imgElement = (Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src)) continue;
                Url imageUrl = new Url(src, document.BaseURI);
                string ext = Path.GetExtension(imageUrl.ToString());
                if (ext.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                    ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    total++;
                }
            }
            using (HttpClient httpClient = new HttpClient())
            {
                int downloaded = 0;
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src)) continue;
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
                    downloaded++;
                    Console.WriteLine($"Downloaded {downloaded} of {total} images.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}