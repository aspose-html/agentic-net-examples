// Expose a public API method that returns a collection of file paths for all extracted SVGs from a given URL.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/sample.html";
            string outputFolder = "ExtractedSvgs";

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
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        var document = new Aspose.Html.HTMLDocument(url);
        HTMLCollection svgs = document.GetElementsByTagName("svg");

        var result = new List<string>();

        for (int i = 0; i < svgs.Length; i++)
        {
            var element = svgs[i] as Aspose.Html.HTMLElement;
            if (element == null)
                continue;

            string svgContent = element.OuterHTML;
            string fileName = $"{i}.svg";
            string filePath = Path.Combine(outputFolder, fileName);
            File.WriteAllText(filePath, svgContent);
            result.Add(filePath);
        }

        return result;
    }
}