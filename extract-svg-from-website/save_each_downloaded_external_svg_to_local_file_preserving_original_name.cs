// Save each downloaded external SVG to a local .svg file preserving the original file name.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            DownloadAndSaveSvgsAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static async Task DownloadAndSaveSvgsAsync()
    {
        string[] svgUrls = new string[]
        {
            "https://example.com/image1.svg",
            "https://example.com/graphics/logo.svg"
        };

        string outputDir = "Svgs";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        using (HttpClient client = new HttpClient())
        {
            foreach (string url in svgUrls)
            {
                string svgContent = await client.GetStringAsync(url);
                string fileName = Path.GetFileName(new Uri(url).AbsolutePath);
                string outputPath = Path.Combine(outputDir, fileName);

                using (Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, url))
                {
                    doc.Save(outputPath);
                }

                Console.WriteLine($"Saved SVG: {outputPath}");
            }
        }
    }
}