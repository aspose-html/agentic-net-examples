// Build a command‑line interface that accepts target URLs and extracts all supported resources.

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
            string[] targetUrls = args.Length > 0 ? args : new string[] { "https://example.com" };
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string url in targetUrls)
                {
                    HTMLDocument document = new HTMLDocument(url);
                    HTMLCollection images = document.GetElementsByTagName("img");

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

            Console.WriteLine("Resources extraction completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}