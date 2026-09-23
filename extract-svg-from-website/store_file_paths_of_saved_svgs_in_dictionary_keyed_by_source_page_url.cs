// Store the file paths of saved SVGs in a dictionary keyed by the source page URL.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            var urlToSvgPath = new Dictionary<string, string>();
            var urls = new List<string>
            {
                "https://example.com/page1",
                "https://example.com/page2"
            };

            string outputDir = "OutputSvgs";
            Directory.CreateDirectory(outputDir);

            foreach (var url in urls)
            {
                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
                string outputPath = Path.Combine(outputDir, $"{Guid.NewGuid()}.svg");

                using (Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, url))
                {
                    doc.Save(outputPath);
                }

                urlToSvgPath[url] = outputPath;
            }

            foreach (var kvp in urlToSvgPath)
            {
                Console.WriteLine($"URL: {kvp.Key} => SVG Path: {kvp.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}