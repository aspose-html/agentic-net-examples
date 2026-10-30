// Batch convert HTML files in subfolders to PNG while preserving original folder hierarchy.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            // Ensure output root exists
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files recursively
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories))
            {
                // Compute relative path and corresponding output PNG path
                string relativePath = Path.GetRelativePath(inputFolder, htmlPath);
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(relativePath, ".png"));

                // Ensure the output subdirectory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load HTML document and convert to PNG
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }

                Console.WriteLine($"Converted: {htmlPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}