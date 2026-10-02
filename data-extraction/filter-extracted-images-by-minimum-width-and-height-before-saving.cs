// Filter extracted images by minimum width and height before saving.

using System;
using System.IO;
using System.Net.Http;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file path
            string htmlPath = "sample.html";
            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = @"<html><body>" +
                                     @"<img src='https://via.placeholder.com/150' />" +
                                     @"<img src='https://via.placeholder.com/50' />" +
                                     @"<img src='https://via.placeholder.com/200x100' />" +
                                     @"</body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Output directory for extracted images
            string outputDir = "ExtractedImages";
            Directory.CreateDirectory(outputDir);

            // Minimum dimensions
            int minWidth = 100;
            int minHeight = 100;

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            using (HttpClient httpClient = new HttpClient())
            {
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve relative URLs against the document base URI
                    Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();

                    // Download image bytes
                    byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                    // Check image dimensions
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        using (Image img = Image.FromStream(ms))
                        {
                            if (img.Width < minWidth || img.Height < minHeight)
                                continue; // Skip images that do not meet size criteria
                        }
                    }

                    // Save image to output directory
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}