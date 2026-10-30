// Include external images as base64‑encoded data URIs within the generated HTML file.

using System;

public class Program
{
    public static async System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><h1>Sample</h1><img src=\"https://via.placeholder.com/150\" alt=\"sample\"/></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
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

                    System.Uri baseUri = new System.Uri(document.BaseURI.ToString(), System.UriKind.Absolute);
                    System.Uri resolvedUri = new System.Uri(baseUri, src);
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(resolvedUri.AbsoluteUri);
                    string mimeType = GetMimeType(System.IO.Path.GetExtension(resolvedUri.AbsolutePath));
                    string dataUri = "data:" + mimeType + ";base64," + System.Convert.ToBase64String(imageBytes);
                    imageElement.SetAttribute("src", dataUri);
                }

                document.Save(outputPath);
            }

            System.Console.WriteLine("HTML saved with embedded images to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static string GetMimeType(string extension)
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