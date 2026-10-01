// Convert SVG files with spaces in their names to GIF, verifying that output filenames preserve spacing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define a directory to work in
            string workDir = Path.Combine(Directory.GetCurrentDirectory(), "SvgSamples");
            if (!Directory.Exists(workDir))
                Directory.CreateDirectory(workDir);

            // Create sample SVG files with spaces in their names
            string[] sampleFiles = new string[]
            {
                Path.Combine(workDir, "sample 1.svg"),
                Path.Combine(workDir, "example test.svg")
            };

            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
  <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
</svg>";

            foreach (string filePath in sampleFiles)
            {
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, svgContent);
            }

            // Prepare conversion options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert each SVG file to GIF, preserving spaces in the output filename
            string[] svgFiles = Directory.GetFiles(workDir, "*.svg");
            foreach (string svgPath in svgFiles)
            {
                string outputPath = Path.ChangeExtension(svgPath, ".gif");
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);
                Console.WriteLine("Converted: \"" + Path.GetFileName(svgPath) + "\" -> \"" + Path.GetFileName(outputPath) + "\"");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}