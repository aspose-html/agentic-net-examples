// Resolve relative URLs to absolute URLs using the Url class and the document BaseURI.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><base href=\"https://example.com/subdir/\"/></head><body><img src=\"images/pic.png\"/><img src=\"https://cdn.com/abs.jpg\"/></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                        continue;

                    Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                    Console.WriteLine($"Original src: {src}");
                    Console.WriteLine($"Resolved absolute URL: {absoluteUrl}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}