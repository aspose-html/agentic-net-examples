// Load an HTML document, replace all relative image URLs with absolute URLs, and save the updated file.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            using (HTMLDocument document = new HTMLDocument(inputPath))
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

                    Uri baseUri = new Uri(document.BaseURI.ToString(), UriKind.Absolute);
                    Uri resolvedUri = new Uri(baseUri, src);
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(resolvedUri.AbsoluteUri);
                    string mimeType = GetMimeType(Path.GetExtension(resolvedUri.AbsolutePath));
                    string dataUri = "data:" + mimeType + ";base64," + Convert.ToBase64String(imageBytes);
                    imageElement.SetAttribute("src", dataUri);
                }

                document.Save(outputPath);
            }
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