// Provide an option to rename saved SVG files using a pattern that includes the source page domain and an index.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com/page.html";
            Uri uri = new Uri(sourceUrl);
            string domain = uri.Host;

            string[] svgContents = new string[]
            {
                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>",
                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" style=\"fill:blue\"/></svg>"
            };

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            for (int i = 0; i < svgContents.Length; i++)
            {
                string svgContent = svgContents[i];
                using (Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, "about:blank"))
                {
                    string outputPath = Path.Combine(outputDir, $"{domain}_{i + 1}.svg");
                    doc.Save(outputPath);
                    Console.WriteLine($"Saved SVG to {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}