// Save each downloaded external SVG file to the output folder with .svg extension.

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
            string[] svgUrls = new string[]
            {
                "https://example.com/image1.svg",
                "https://example.com/image2.svg"
            };

            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            using HttpClient httpClient = new HttpClient();

            foreach (string url in svgUrls)
            {
                string svgContent = await httpClient.GetStringAsync(url);
                Uri uri = new Uri(url);
                string fileName = Path.GetFileNameWithoutExtension(uri.LocalPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".svg");

                using (SVGDocument doc = new SVGDocument(svgContent, uri.GetLeftPart(UriPartial.Path)))
                {
                    doc.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}