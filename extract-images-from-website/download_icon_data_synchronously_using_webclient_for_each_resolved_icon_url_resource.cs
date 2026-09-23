// Download icon data synchronously using WebClient for each resolved icon URL resource.

using System;
using System.IO;
using System.Net;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<img src='https://example.com/favicon.ico' />" +
                                 "<img src='https://example.com/logo.png' />" +
                                 "</body></html>";
            using (HTMLDocument document = new HTMLDocument(htmlContent))
            {
                string outputDir = "DownloadedIcons";
                Directory.CreateDirectory(outputDir);

                HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                        continue;

                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageBytes = webClient.DownloadData(urlString);
                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }

            Console.WriteLine("Icon download completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}