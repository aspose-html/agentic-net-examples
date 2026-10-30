// Open a web page using Aspose.HTML Document and extract raster images from <img> tags.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            // Define the web page URL and output directory
            string pageUrl = "https://example.com";
            string outputDir = "ExtractedImages";

            // Ensure output directory exists
            if (!System.IO.Directory.Exists(outputDir))
            {
                System.IO.Directory.CreateDirectory(outputDir);
            }

            // Load the HTML document from the URL
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl))
            {
                // Get all <img> elements
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

                // HttpClient for downloading images
                using (HttpClient httpClient = new HttpClient())
                {
                    int index = 0;
                    foreach (Aspose.Html.Dom.Element img in images)
                    {
                        string src = img.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                        {
                            continue;
                        }

                        // Resolve absolute URL based on document's BaseURI
                        Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                        string imageUrl = absoluteUrl.ToString();

                        // Determine file name
                        string fileName;
                        try
                        {
                            Uri uri = new Uri(imageUrl);
                            fileName = System.IO.Path.GetFileName(uri.LocalPath);
                            if (string.IsNullOrEmpty(fileName))
                            {
                                fileName = $"image_{index}.jpg";
                            }
                        }
                        catch
                        {
                            fileName = $"image_{index}.jpg";
                        }

                        string outputPath = System.IO.Path.Combine(outputDir, fileName);

                        // Download and save the image
                        byte[] imageData = httpClient.GetByteArrayAsync(imageUrl).Result;
                        System.IO.File.WriteAllBytes(outputPath, imageData);

                        Console.WriteLine($"Saved image: {outputPath}");
                        index++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}