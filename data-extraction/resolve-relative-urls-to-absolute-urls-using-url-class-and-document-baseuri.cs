// Resolve relative URLs to absolute URLs using the Url class and the document BaseURI.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputHtml = "<html><body><img src=\"image.png\" /></body></html>";
            string baseUri = "https://example.com/";
            string outputPath = "output.html";

            using (HTMLDocument document = new HTMLDocument(inputHtml, baseUri))
            using (HttpClient httpClient = new HttpClient())
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

                    Url absoluteUrl = new Url(src, document.BaseURI);
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(absoluteUrl.ToString());
                    string mimeType = GetMimeType(Path.GetExtension(absoluteUrl.ToString()));
                    string dataUri = "data:" + mimeType + ";base64," + Convert.ToBase64String(imageBytes);
                    imageElement.SetAttribute("src", dataUri);
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed. Output saved to " + Path.GetFullPath("output.html"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string GetMimeType(string extension)
    {
        switch (extension.ToLowerInvariant())
        {
            case ".png": return "image/png";
            case ".jpg":
            case ".jpeg": return "image/jpeg";
            case ".gif": return "image/gif";
            case ".svg": return "image/svg+xml";
            case ".webp": return "image/webp";
            default: return "application/octet-stream";
        }
    }
}