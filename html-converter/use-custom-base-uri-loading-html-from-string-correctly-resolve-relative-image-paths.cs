// Use a custom base URI when loading HTML from string to correctly resolve relative image paths.

namespace Example
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><img src=\"images/pic.png\"/></body></html>";
                string baseUri = "https://example.com/";
                string outputPath = "output.html";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
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

                        System.Uri baseUriObj = new System.Uri(document.BaseURI.ToString(), System.UriKind.Absolute);
                        System.Uri resolvedUri = new System.Uri(baseUriObj, src);
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(resolvedUri.AbsoluteUri);
                        string mimeType = GetMimeType(System.IO.Path.GetExtension(resolvedUri.AbsolutePath));
                        string dataUri = "data:" + mimeType + ";base64," + System.Convert.ToBase64String(imageBytes);
                        imageElement.SetAttribute("src", dataUri);
                    }
                    document.Save(outputPath);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
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
}