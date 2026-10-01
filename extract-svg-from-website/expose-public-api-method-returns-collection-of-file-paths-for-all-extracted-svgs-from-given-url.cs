// Expose a public API method that returns a collection of file paths for all extracted SVGs from a given URL.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputFolder = "SvgsOutput";
            List<string> svgFiles = ExtractSvgs(url, outputFolder);
            Console.WriteLine("Extracted SVG files:");
            foreach (string file in svgFiles)
            {
                Console.WriteLine(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static List<string> ExtractSvgs(string url, string outputFolder)
    {
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
        Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
        List<string> result = new List<string>();

        for (int i = 0; i < svgs.Length; i++)
        {
            Aspose.Html.HTMLElement svgElement = svgs[i] as Aspose.Html.HTMLElement;
            if (svgElement == null)
                continue;

            string svgContent = svgElement.OuterHTML;
            string filePath = Path.Combine(outputFolder, $"{i}.svg");
            File.WriteAllText(filePath, svgContent);
            result.Add(filePath);
        }

        return result;
    }
}