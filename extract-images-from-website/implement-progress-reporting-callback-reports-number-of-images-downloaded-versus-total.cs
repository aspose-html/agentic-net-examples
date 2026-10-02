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
            string inputHtml = "sample.html";
            string outputDir = "downloaded_images";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            if (!File.Exists(inputHtml))
            {
                string htmlContent = "<html><body>" +
                                     "<img src=\"https://via.placeholder.com/150\"/>" +
                                     "<img src=\"https://via.placeholder.com/200\"/>" +
                                     "</body></html>";
                File.WriteAllText(inputHtml, htmlContent);
            }

            using (HTMLDocument document = new HTMLDocument(inputHtml))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                int total = images.Length;

                using (HttpClient httpClient = new HttpClient())
                {
                    for (int i = 0; i < total; i++)
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

                        Console.WriteLine($"Downloaded {i + 1}/{total}: {fileName}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}