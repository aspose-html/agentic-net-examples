// Filter extracted images by minimum width and height before saving.

using System;
using System.IO;
using System.Net.Http;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputDir = "output";
            int minWidth = 200;
            int minHeight = 200;

            HTMLDocument document = new HTMLDocument(htmlPath);
            HTMLCollection images = document.GetElementsByTagName("img");
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

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        using (Image img = Image.FromStream(ms))
                        {
                            if (img.Width < minWidth || img.Height < minHeight)
                                continue;
                        }
                    }

                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}