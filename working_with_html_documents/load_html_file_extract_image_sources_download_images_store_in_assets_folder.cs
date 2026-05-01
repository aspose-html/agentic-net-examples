// Load an HTML file, extract all image sources, download each image, and store in assets folder.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

namespace ImageExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                HTMLDocument document = new HTMLDocument(htmlPath);
                HTMLCollection images = document.GetElementsByTagName("img");
                string outputDir = "assets";
                System.IO.Directory.CreateDirectory(outputDir);
                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        Element imgElement = (Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src)) continue;
                        Url imageUrl = new Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();
                        string extension = System.IO.Path.GetExtension(urlString);
                        if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) && !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) && !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)) continue;
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
                        string fileName = System.IO.Path.GetFileName(urlString);
                        string savePath = System.IO.Path.Combine(outputDir, fileName);
                        System.IO.File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}