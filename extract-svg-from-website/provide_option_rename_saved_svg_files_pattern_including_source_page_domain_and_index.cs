// Provide an option to rename saved SVG files using a pattern that includes the source page domain and an index.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string[] sourceUrls = new string[]
            {
                "https://example.com/page1",
                "https://sample.org/graphics",
                "https://test.net/diagram"
            };

            string[] svgContents = new string[]
            {
                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>",
                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><circle cx=\"100\" cy=\"100\" r=\"80\" fill=\"green\"/></svg>",
                "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"150\" height=\"150\"><polygon points=\"75,0 150,150 0,150\" fill=\"blue\"/></svg>"
            };

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            for (int i = 0; i < sourceUrls.Length; i++)
            {
                string url = sourceUrls[i];
                string svgContent = svgContents[i];
                string domain = new Uri(url).Host.Replace(".", "_");
                string fileName = $"{domain}_{i + 1}.svg";
                string outputPath = Path.Combine(outputDir, fileName);

                using (Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, url))
                {
                    doc.Save(outputPath);
                }

                Console.WriteLine($"Saved SVG to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}