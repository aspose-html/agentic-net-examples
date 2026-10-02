// Honor the <base> tag when constructing absolute URLs for resource download.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file with a <base> tag if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<html><head><base href=""https://via.placeholder.com/""/></head><body><img src=""150.png""/></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            using (HttpClient httpClient = new HttpClient())
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(src))
                    {
                        continue;
                    }

                    // Resolve the URL using the document's base URI (honors <base> tag)
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