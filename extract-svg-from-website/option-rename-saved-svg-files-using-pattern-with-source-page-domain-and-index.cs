// Provide an option to rename saved SVG files using a pattern that includes the source page domain and an index.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Sample source page URLs
            string[] sourceUrls = new string[]
            {
                "https://example.com/page1",
                "https://sample.org/gallery"
            };

            // Simple SVG content to be saved
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";

            // Output directory
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);

            for (int i = 0; i < sourceUrls.Length; i++)
            {
                string sourceUrl = sourceUrls[i];
                // Extract domain from URL
                string domain = new Uri(sourceUrl).Host;

                // Build output file name using domain and index
                string fileName = $"{domain}_svg_{i + 1}.svg";
                string outputPath = System.IO.Path.Combine(outputDir, fileName);

                // Load SVG document with base URI (source page)
                using (SVGDocument doc = new SVGDocument(svgContent, sourceUrl))
                {
                    // Save SVG to the generated path
                    doc.Save(outputPath);
                }

                Console.WriteLine($"Saved SVG for '{domain}' as '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}