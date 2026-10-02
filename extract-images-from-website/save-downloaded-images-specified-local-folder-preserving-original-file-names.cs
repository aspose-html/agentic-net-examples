// Save downloaded images to a specified local folder preserving original file names.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare input HTML file
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(inputHtmlPath))
            {
                string htmlContent = "<html><body>" +
                                     "<img src=\"https://via.placeholder.com/150.png\" />" +
                                     "<img src=\"https://via.placeholder.com/200.jpg\" />" +
                                     "</body></html>";
                File.WriteAllText(inputHtmlPath, htmlContent);
            }

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedImages");
            Directory.CreateDirectory(outputDir);

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(inputHtmlPath))
            using (HttpClient httpClient = new HttpClient())
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Element imageElement = (Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                        continue;

                    Uri baseUri = new Uri(document.BaseURI.ToString(), UriKind.Absolute);
                    Uri resolvedUri = new Uri(baseUri, src);

                    byte[] imageBytes = httpClient.GetByteArrayAsync(resolvedUri).GetAwaiter().GetResult();

                    string fileName = Path.GetFileName(resolvedUri.LocalPath);
                    if (string.IsNullOrEmpty(fileName))
                        fileName = Guid.NewGuid().ToString();

                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }

            Console.WriteLine("Images have been downloaded to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}