// Save downloaded images to a specified local folder preserving original file names.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Prepare input HTML file
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = @"<html><body>" +
                                    @"<img src=""https://via.placeholder.com/150"" />" +
                                    @"<img src=""https://via.placeholder.com/200"" />" +
                                    @"</body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedImages");
            Directory.CreateDirectory(outputDir);

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(inputHtmlPath, Directory.GetCurrentDirectory()))
            {
                // Get all img elements
                HTMLCollection images = document.GetElementsByTagName("img");

                using (HttpClient httpClient = new HttpClient())
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        Element imgElement = (Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrWhiteSpace(src))
                        {
                            continue;
                        }

                        // Resolve absolute URI
                        Uri baseUri = new Uri(document.BaseURI.ToString(), UriKind.Absolute);
                        Uri resolvedUri = new Uri(baseUri, src);

                        // Download image bytes
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(resolvedUri.AbsoluteUri);

                        // Preserve original file name
                        string fileName = Path.GetFileName(resolvedUri.LocalPath);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            // Fallback to a generated name if URL does not contain a file name
                            fileName = $"image_{i}.bin";
                        }

                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                    }
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