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
            // Prepare sample HTML with an image
            string inputPath = "input.html";
            string htmlContent = "<html><body><img src=\"https://example.com/images/sample.png\" /></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Output directory for downloaded images
            string outputDir = "downloaded_images";
            Directory.CreateDirectory(outputDir);

            using (HTMLDocument document = new HTMLDocument(inputPath))
            using (HttpClient httpClient = new HttpClient())
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Extract file name from URL
                    string fileName = Path.GetFileName(urlString);
                    if (string.IsNullOrEmpty(fileName))
                        continue;

                    string savePath = Path.Combine(outputDir, fileName);
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
                    File.WriteAllBytes(savePath, imageBytes);
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