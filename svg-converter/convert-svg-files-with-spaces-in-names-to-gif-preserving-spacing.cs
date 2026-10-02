// Convert SVG files with spaces in their names to GIF, verifying that output filenames preserve spacing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input";
            string outputDir = "output";
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create sample SVG files with spaces in their names
            var sampleFiles = new[]
            {
                Path.Combine(inputDir, "sample 1.svg"),
                Path.Combine(inputDir, "example test.svg")
            };
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            foreach (var filePath in sampleFiles)
            {
                File.WriteAllText(filePath, svgContent);
            }

            // Convert each SVG to GIF, preserving spaces in the filename
            foreach (var svgPath in Directory.GetFiles(inputDir, "*.svg"))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".gif");

                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

                if (File.Exists(outputPath))
                {
                    Console.WriteLine($"Converted '{Path.GetFileName(svgPath)}' to '{Path.GetFileName(outputPath)}' successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to convert '{Path.GetFileName(svgPath)}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}