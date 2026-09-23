// Filter extracted images by minimum width and height before saving.

using System;
using System.IO;
using System.Net.Http;
using System.Drawing;

namespace AsposeHtmlImageExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                if (!File.Exists(htmlPath))
                {
                    string sampleHtml = "<html><body><img src=\"https://via.placeholder.com/150\"/><img src=\"https://via.placeholder.com/50\"/></body></html>";
                    File.WriteAllText(htmlPath, sampleHtml);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                string outputDir = "ExtractedImages";
                Directory.CreateDirectory(outputDir);

                int minWidth = 100;
                int minHeight = 100;

                using (HttpClient httpClient = new HttpClient())
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                            continue;

                        string absoluteUrl;
                        if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                        {
                            absoluteUrl = src;
                        }
                        else
                        {
                            Uri baseUri = new Uri(document.BaseURI);
                            Uri resolved = new Uri(baseUri, src);
                            absoluteUrl = resolved.ToString();
                        }

                        byte[] imageBytes = httpClient.GetByteArrayAsync(absoluteUrl).GetAwaiter().GetResult();

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            using (Image img = Image.FromStream(ms))
                            {
                                if (img.Width < minWidth || img.Height < minHeight)
                                    continue;
                            }
                        }

                        string fileName = Path.GetFileName(absoluteUrl);
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
}