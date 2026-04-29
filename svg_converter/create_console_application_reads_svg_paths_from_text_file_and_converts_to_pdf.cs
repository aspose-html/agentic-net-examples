// Create a console application that reads SVG file paths from a text file and converts each to PDF.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace SvgToPdfBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the text file containing SVG file paths (one per line)
                string listFilePath = "svg_paths.txt";

                if (!File.Exists(listFilePath))
                {
                    Console.WriteLine($"List file not found: {listFilePath}");
                    return;
                }

                // Read all non‑empty lines
                string[] svgPaths = File.ReadAllLines(listFilePath);
                foreach (string rawPath in svgPaths)
                {
                    string sourcePath = rawPath.Trim();
                    if (string.IsNullOrEmpty(sourcePath))
                        continue;

                    // Determine output PDF path (same folder, same name with .pdf extension)
                    string outputPath = Path.ChangeExtension(sourcePath, ".pdf");

                    // Create default PDF save options
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Convert SVG file to PDF
                    Converter.ConvertSVG(sourcePath, options, outputPath);

                    Console.WriteLine($"Converted: {sourcePath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}