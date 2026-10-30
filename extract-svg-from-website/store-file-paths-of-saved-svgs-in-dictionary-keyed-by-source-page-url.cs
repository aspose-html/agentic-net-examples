// Store the file paths of saved SVGs in a dictionary keyed by the source page URL.

using System;
using System.Collections.Generic;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            List<string> urls = new List<string>
            {
                "https://example.com/page1",
                "https://example.com/page2"
            };

            Dictionary<string, string> svgPaths = new Dictionary<string, string>();
            int index = 1;

            foreach (string url in urls)
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>";
                string outputPath = $"output_page{index}.svg";

                using (SVGDocument doc = new SVGDocument(svgContent, "about:blank"))
                {
                    doc.Save(outputPath);
                }

                svgPaths[url] = outputPath;
                index++;
            }

            foreach (KeyValuePair<string, string> kvp in svgPaths)
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