// Implement batch conversion of a folder of SVG files to JPEG with uniform quality.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

namespace SvgBatchToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output folders
                string inputFolder = "InputSvgs";
                string outputFolder = "OutputJpegs";

                // Ensure the output directory exists
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Get all SVG files in the input folder
                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
                int total = svgFiles.Length;

                for (int i = 0; i < total; i++)
                {
                    string svgPath = svgFiles[i];
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(svgPath) + ".jpg");

                    // Load the SVG document
                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        // Configure JPEG save options
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                        options.UseAntialiasing = true;
                        options.HorizontalResolution = 200; // DPI
                        options.VerticalResolution = 200;   // DPI
                        options.BackgroundColor = Color.White;

                        // Convert SVG to JPEG
                        Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                    }

                    // Report progress
                    int percent = (i + 1) * 100 / total;
                    Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
                }

                Console.WriteLine("Batch conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}