// Implement a progress reporter for SVG to TIFF batch conversion, indicating compression level for each file.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output folders
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputTiffs";

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                // Load SVG document
                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    // Configure TIFF save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    options.Compression = Compression.None;      // No compression
                    options.HorizontalResolution = 200;          // 200 DPI
                    options.VerticalResolution = 200;            // 200 DPI

                    // Convert SVG to TIFF
                    Converter.ConvertSVG(document, options, outputPath);
                }

                // Report progress and compression level
                int percent = (i + 1) * 100 / total;
                Console.WriteLine(
                    $"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)} - Compression: None");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}