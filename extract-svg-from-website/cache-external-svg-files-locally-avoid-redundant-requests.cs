// Cache downloaded external SVG files locally to avoid redundant network requests.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define SVG URLs to cache
            string[] svgUrls = new string[]
            {
                "https://upload.wikimedia.org/wikipedia/commons/6/6b/Bitmap_VS_SVG.svg",
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/acid.svg"
            };

            // Define cache folder
            string cacheFolder = Path.Combine(Path.GetTempPath(), "SvgCache");
            Directory.CreateDirectory(cacheFolder);

            // HttpClient for downloading
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string url in svgUrls)
                {
                    Uri uri = new Uri(url);
                    string fileName = Path.GetFileName(uri.LocalPath);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = Guid.NewGuid().ToString() + ".svg";
                    }
                    string localPath = Path.Combine(cacheFolder, fileName);

                    // Download if not cached
                    if (!File.Exists(localPath))
                    {
                        Console.WriteLine($"Downloading {url}...");
                        byte[] data = httpClient.GetByteArrayAsync(uri).Result;
                        File.WriteAllBytes(localPath, data);
                        Console.WriteLine($"Saved to {localPath}");
                    }
                    else
                    {
                        Console.WriteLine($"Using cached file {localPath}");
                    }

                    // Load SVG and convert to PNG
                    using (SVGDocument svgDoc = new SVGDocument(localPath))
                    {
                        string outputPng = Path.Combine(cacheFolder, Path.GetFileNameWithoutExtension(fileName) + ".png");
                        ImageSaveOptions options = new ImageSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, options, outputPng);
                        Console.WriteLine($"Converted to PNG: {outputPng}");
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