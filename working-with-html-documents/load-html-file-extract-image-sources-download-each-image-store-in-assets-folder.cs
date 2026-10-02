// Load an HTML file, extract all image sources, download each image, and store in assets folder.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output directory
            string inputHtmlPath = "sample.html";
            string outputDir = "assets";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = @"<html><body>" +
                                    @"<img src='https://via.placeholder.com/150' />" +
                                    @"<img src='https://via.placeholder.com/200' />" +
                                    @"</body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputHtmlPath);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Ensure the assets folder exists
            Directory.CreateDirectory(outputDir);

            // Download each image and save to the assets folder
            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    Element imgElement = (Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve the image URL relative to the document base URI
                    Url imageUrl = new Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Download image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Determine file name and save path
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);

                    // Write the image to disk
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }

            Console.WriteLine("Images have been downloaded to the '" + outputDir + "' folder.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}