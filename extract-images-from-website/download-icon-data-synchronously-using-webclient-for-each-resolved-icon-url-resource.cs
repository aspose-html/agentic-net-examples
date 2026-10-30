// Download icon data synchronously using WebClient for each resolved icon URL resource.

using System;
using System.IO;
using System.Net;
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
            string inputPath = "sample.html";
            string outputDir = "icons";
            Directory.CreateDirectory(outputDir);

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><img src=\"https://example.com/favicon.ico\"/></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                using (WebClient webClient = new WebClient())
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

                        if (!extension.Equals(".ico", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) &&
                            !extension.Equals(".svg", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        byte[] imageBytes = webClient.DownloadData(urlString);
                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }

            Console.WriteLine("Icons downloaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}