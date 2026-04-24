// Identify external SVG files referenced by <img> tags and download them to local storage.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputHtmlPath = "output.html";
            string downloadFolder = "downloaded_svgs";

            Directory.CreateDirectory(downloadFolder);

            var document = new HTMLDocument(inputHtmlPath);
            var imgNodes = document.QuerySelectorAll("img");
            using var httpClient = new HttpClient();

            for (int i = 0; i < imgNodes.Length; i++)
            {
                var imgElement = (Element)imgNodes[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                if (src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    Uri svgUri;
                    if (!Uri.TryCreate(src, UriKind.Absolute, out svgUri))
                    {
                        var baseUri = new Uri(new FileInfo(inputHtmlPath).FullName);
                        svgUri = new Uri(baseUri, src);
                    }

                    byte[] svgData = await httpClient.GetByteArrayAsync(svgUri);
                    string fileName = Path.GetFileName(svgUri.LocalPath);
                    string localPath = Path.Combine(downloadFolder, fileName);
                    await File.WriteAllBytesAsync(localPath, svgData);

                    imgElement.SetAttribute("src", localPath);
                }
            }

            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}