// Save each downloaded image to a specified output folder preserving original filenames.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            // Prepare input HTML file
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<html><body><img src=\"https://via.placeholder.com/150\" /><img src=\"https://via.placeholder.com/200\" /></body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "downloaded_images");
            Directory.CreateDirectory(outputDir);

            // Load HTML document
            using (var document = new Aspose.Html.HTMLDocument(inputHtmlPath, Directory.GetCurrentDirectory()))
            {
                // Get all img elements
                HTMLCollection images = document.GetElementsByTagName("img");
                using (var httpClient = new HttpClient())
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

                        // Determine filename
                        string fileName = Path.GetFileName(resolvedUri.LocalPath);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = $"image_{i}.bin";
                        }

                        // Save to output folder
                        string outputPath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(outputPath, imageBytes);
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