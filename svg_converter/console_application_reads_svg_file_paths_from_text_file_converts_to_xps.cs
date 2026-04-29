// Write a console application that reads SVG file paths from a text file and converts them to XPS.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace SvgToXpsConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the text file containing SVG file paths (one per line)
                string listFilePath = args.Length > 0 ? args[0] : "svglist.txt";

                if (!File.Exists(listFilePath))
                {
                    Console.WriteLine($"List file not found: {listFilePath}");
                    return;
                }

                // Read all SVG paths from the file
                string[] svgPaths = File.ReadAllLines(listFilePath);

                foreach (string rawPath in svgPaths)
                {
                    string svgPath = rawPath.Trim();
                    if (string.IsNullOrEmpty(svgPath))
                        continue;

                    if (!File.Exists(svgPath))
                    {
                        Console.WriteLine($"SVG file not found: {svgPath}");
                        continue;
                    }

                    // Determine output XPS file path (same folder, same name with .xps extension)
                    string outputPath = Path.ChangeExtension(svgPath, ".xps");

                    // Create default XPS save options
                    XpsSaveOptions options = new XpsSaveOptions();

                    // Convert SVG to XPS
                    Converter.ConvertSVG(svgPath, options, outputPath);

                    Console.WriteLine($"Converted '{svgPath}' to '{outputPath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}