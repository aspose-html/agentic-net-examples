// Open a web page using Aspose.HTML Document and extract raster images from <img> tags.

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
            // Define paths
            string htmlPath = "sample.html";
            string outputDir = "images";

            // Create sample HTML file
            string htmlContent = "<html><body><img src=\"https://via.placeholder.com/150\"/></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Get all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Download each image
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

                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }

            Console.WriteLine("Image extraction completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}