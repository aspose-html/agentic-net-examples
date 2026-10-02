// Cache downloaded external SVG files locally to avoid redundant network requests.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG URLs
            string[] svgUrls = new string[]
            {
                "https://upload.wikimedia.org/wikipedia/commons/6/6b/Bitmap_VS_SVG.svg",
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/acid.svg"
            };

            // Cache directory
            string cacheDir = Path.Combine(Directory.GetCurrentDirectory(), "svgCache");
            Directory.CreateDirectory(cacheDir);

            // HttpClient for downloading
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string url in svgUrls)
                {
                    // Determine local file name
                    string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = Guid.NewGuid().ToString() + ".svg";
                    }

                    string localPath = Path.Combine(cacheDir, fileName);

                    // Download if not cached
                    if (!File.Exists(localPath))
                    {
                        byte[] data = httpClient.GetByteArrayAsync(url).Result;
                        File.WriteAllBytes(localPath, data);
                        Console.WriteLine($"Downloaded and cached: {url}");
                    }
                    else
                    {
                        Console.WriteLine($"Using cached file for: {url}");
                    }

                    // Load SVG content
                    string svgContent = File.ReadAllText(localPath);
                    string baseUri = new Uri(localPath).AbsoluteUri;

                    // Prepare output image path
                    string outputImagePath = Path.Combine(Directory.GetCurrentDirectory(),
                        Path.GetFileNameWithoutExtension(fileName) + ".png");

                    // Set image save options
                    ImageSaveOptions options = new ImageSaveOptions();
                    options.Format = ImageFormat.Png;

                    // Convert SVG to PNG
                    Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputImagePath);
                    Console.WriteLine($"Converted to PNG: {outputImagePath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}