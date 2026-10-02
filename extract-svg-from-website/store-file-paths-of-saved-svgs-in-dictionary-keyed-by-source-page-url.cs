// Store the file paths of saved SVGs in a dictionary keyed by the source page URL.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "SampleHtml");
            Directory.CreateDirectory(baseDir);

            var htmlFiles = new List<string>();
            for (int i = 1; i <= 2; i++)
            {
                string filePath = Path.Combine(baseDir, $"page{i}.html");
                File.WriteAllText(filePath, $"<html><body><h1>Sample Page {i}</h1></body></html>");
                htmlFiles.Add(filePath);
            }

            // Dictionary to store SVG paths keyed by source page URL (file path)
            var svgPaths = new Dictionary<string, string>();

            foreach (string htmlPath in htmlFiles)
            {
                // Load HTML document from file
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    // Determine SVG output path
                    string svgPath = Path.ChangeExtension(htmlPath, ".svg");

                    // Save as SVG
                    document.Save(svgPath);

                    // Store in dictionary
                    svgPaths[htmlPath] = svgPath;
                }
            }

            // Output results
            foreach (var kvp in svgPaths)
            {
                Console.WriteLine($"Source: {kvp.Key}");
                Console.WriteLine($"Saved SVG: {kvp.Value}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}