// Save each downloaded external SVG to a local .svg file preserving the original file name.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.Dom.Svg;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var svgUrls = new[]
            {
                "https://example.com/image1.svg",
                "https://example.com/dir/image2.svg"
            };

            using var httpClient = new HttpClient();

            foreach (var url in svgUrls)
            {
                var svgContent = await httpClient.GetStringAsync(url);
                var fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                var outputPath = Path.Combine(Environment.CurrentDirectory, fileName);
                using var doc = new SVGDocument(svgContent, url);
                doc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}