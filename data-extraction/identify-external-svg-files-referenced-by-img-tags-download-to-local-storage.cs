// Identify external SVG files referenced by <img> tags and download them to local storage.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body><img src=\"https://upload.wikimedia.org/wikipedia/commons/6/6b/Bitmap_VS_SVG.svg\" alt=\"sample\"/></body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            var document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Collections.HTMLCollection imgCollection = document.GetElementsByTagName("img");

            string outputDir = "downloaded_svgs";
            Directory.CreateDirectory(outputDir);

            using (var httpClient = new HttpClient())
            {
                for (int i = 0; i < imgCollection.Length; i++)
                {
                    var node = imgCollection[i];
                    var imgElement = node as Aspose.Html.HTMLElement;
                    if (imgElement == null)
                        continue;

                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    if (src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!Uri.TryCreate(src, UriKind.Absolute, out Uri uri))
                            continue;

                        string fileName = Path.GetFileName(uri.LocalPath);
                        if (string.IsNullOrEmpty(fileName))
                            fileName = "image.svg";

                        string localPath = Path.Combine(outputDir, fileName);
                        byte[] data = httpClient.GetByteArrayAsync(uri).Result;
                        File.WriteAllBytes(localPath, data);
                        Console.WriteLine($"Downloaded SVG: {src} -> {localPath}");
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