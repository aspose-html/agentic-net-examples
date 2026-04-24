// Provide an option to rename saved SVG files using a pattern that includes the source page domain and an index.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.Dom.Svg;

class Program
{
    static async Task Main()
    {
        try
        {
            string[] urls = { "https://example.com/page1.svg", "https://example.org/page2.svg" };
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            using HttpClient client = new HttpClient();
            int index = 1;
            foreach (var url in urls)
            {
                string svgContent = await client.GetStringAsync(url);
                string domain = new Uri(url).Host;
                string outputPath = Path.Combine(outputDir, $"{domain}_{index}.svg");
                using SVGDocument doc = new SVGDocument(svgContent, url);
                doc.Save(outputPath);
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}