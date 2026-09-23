// Open a web page using Aspose.HTML Document and extract raster images from <img> tags.

using System;
using System.IO;
using System.Net.Http;

namespace AsposeHtmlImageExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string pageUrl = "https://example.com";
                string outputDir = "ExtractedImages";
                Directory.CreateDirectory(outputDir);

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(pageUrl))
                {
                    Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                    using (HttpClient httpClient = new HttpClient())
                    {
                        for (int i = 0; i < images.Length; i++)
                        {
                            Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                            string src = imgElement.GetAttribute("src");
                            if (string.IsNullOrEmpty(src))
                                continue;

                            Uri absoluteUri = new Uri(new Uri(document.BaseURI), src);
                            string urlString = absoluteUri.ToString();

                            byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                            string fileName = Path.GetFileName(absoluteUri.LocalPath);
                            if (string.IsNullOrEmpty(fileName))
                            {
                                fileName = $"image_{i}.bin";
                            }

                            string savePath = Path.Combine(outputDir, fileName);
                            File.WriteAllBytes(savePath, imageBytes);
                        }
                    }
                }

                Console.WriteLine("Image extraction completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}