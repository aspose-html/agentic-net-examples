// Expose a public API method that returns a collection of file paths for all extracted SVGs from a given URL.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputFolder = "Svgs";

            Directory.CreateDirectory(outputFolder);

            List<string> svgFiles = ExtractSvgFiles(url, outputFolder);

            Console.WriteLine("Extracted SVG files:");
            foreach (string path in svgFiles)
            {
                Console.WriteLine(path);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static List<string> ExtractSvgFiles(string url, string outputFolder)
    {
        var result = new List<string>();

        // Load the HTML document from the specified URL
        HTMLDocument document = new HTMLDocument(url);

        // Get all <svg> elements in the document
        HTMLCollection svgs = document.GetElementsByTagName("svg");

        for (int i = 0; i < svgs.Length; i++)
        {
            // Cast the node to HTMLElement to access SVG-specific properties
            HTMLElement element = svgs[i] as HTMLElement;
            if (element == null)
                continue;

            // Retrieve the outer HTML of the SVG element
            string svgContent = element.OuterHTML;

            // Build the output file path
            string filePath = Path.Combine(outputFolder, $"{i}.svg");

            // Write the SVG content to a file
            File.WriteAllText(filePath, svgContent);

            result.Add(filePath);
        }

        return result;
    }
}