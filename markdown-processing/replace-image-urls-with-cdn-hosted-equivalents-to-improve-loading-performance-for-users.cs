// Replace existing image URLs with CDN-hosted equivalents to improve loading performance for users.

using System;
using System.IO;
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
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src=\"images/pic.jpg\" alt=\"Sample Image\" /></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Element imageElement = (Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                    {
                        continue;
                    }

                    Uri baseUri = new Uri(document.BaseURI.ToString(), UriKind.Absolute);
                    Uri resolvedUri = new Uri(baseUri, src);

                    // Replace the host with a CDN host
                    string cdnHost = "cdn.example.com";
                    UriBuilder builder = new UriBuilder(resolvedUri)
                    {
                        Host = cdnHost
                    };
                    string cdnUrl = builder.Uri.AbsoluteUri;

                    imageElement.SetAttribute("src", cdnUrl);
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}