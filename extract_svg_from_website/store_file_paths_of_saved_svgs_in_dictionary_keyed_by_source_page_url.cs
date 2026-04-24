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
            // Sample source page URLs
            var pageUrls = new List<string>
            {
                "https://example.com/page1",
                "https://example.com/page2"
            };

            // Dictionary to store the mapping: page URL -> saved SVG file path
            var savedSvgPaths = new Dictionary<string, string>();

            foreach (var url in pageUrls)
            {
                // SVG markup to be saved (could be fetched based on the URL)
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>";

                // Base URI for the SVG document (using the page URL)
                string baseUri = url;

                // Define an output file path for the SVG
                string outputPath = $"saved_{Guid.NewGuid()}.svg";

                // Create SVGDocument from markup and base URI, then save it
                using (SVGDocument doc = new SVGDocument(svgContent, baseUri))
                {
                    doc.Save(outputPath);
                }

                // Store the mapping in the dictionary
                savedSvgPaths[url] = outputPath;
            }

            // Example: output the stored paths
            foreach (var kvp in savedSvgPaths)
            {
                Console.WriteLine($"Page URL: {kvp.Key}");
                Console.WriteLine($"Saved SVG Path: {kvp.Value}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}