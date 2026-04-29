// Implement a progress reporter for SVG to GIF batch conversion, displaying current file name and index.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output folders (use arguments or defaults)
            string inputFolder = args.Length > 0 ? args[0] : "InputSvgs";
            string outputFolder = args.Length > 1 ? args[1] : "OutputGifs";

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".gif");

                // Load SVG document
                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    // Configure GIF output options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    // Optional rendering settings
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;

                    // Convert SVG to GIF
                    Converter.ConvertSVG(document, options, outputPath);
                }

                // Report progress
                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}