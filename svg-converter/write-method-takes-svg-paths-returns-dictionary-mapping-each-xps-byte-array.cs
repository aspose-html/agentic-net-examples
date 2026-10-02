// Write a method that takes SVG paths and returns a dictionary mapping each to its XPS byte array.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create sample SVG files
            string svgPath1 = Path.Combine(Directory.GetCurrentDirectory(), "sample1.svg");
            string svgPath2 = Path.Combine(Directory.GetCurrentDirectory(), "sample2.svg");

            string svgContent1 = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string svgContent2 = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green'/></svg>";

            File.WriteAllText(svgPath1, svgContent1);
            File.WriteAllText(svgPath2, svgContent2);

            var svgPaths = new List<string> { svgPath1, svgPath2 };
            Dictionary<string, byte[]> result = ConvertSvgsToXpsBytes(svgPaths);

            foreach (var kvp in result)
            {
                Console.WriteLine($"SVG Path: {kvp.Key}, XPS Size: {kvp.Value.Length} bytes");
            }

            // Clean up sample SVG files
            File.Delete(svgPath1);
            File.Delete(svgPath2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, byte[]> ConvertSvgsToXpsBytes(IEnumerable<string> svgPaths)
    {
        var map = new Dictionary<string, byte[]>();

        foreach (string svgPath in svgPaths)
        {
            // Prepare XPS save options (optional configuration)
            XpsSaveOptions options = new XpsSaveOptions();

            // Generate a temporary file path for the XPS output
            string tempXpsPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xps");

            // Convert SVG to XPS file
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, tempXpsPath);

            // Read the XPS file into a byte array
            byte[] xpsBytes = File.ReadAllBytes(tempXpsPath);
            map[svgPath] = xpsBytes;

            // Delete the temporary XPS file
            File.Delete(tempXpsPath);
        }

        return map;
    }
}