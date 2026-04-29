// Batch convert multiple SVG images to GIF format while applying custom ImageSaveOptions for each file.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

namespace BatchSvgToGif
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output folders
                string inputFolder = @"C:\InputSvgs";
                string outputFolder = @"C:\OutputGifs";

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
                        Path.GetFileNameWithoutExtension(svgPath) + ".gif");

                    // Load SVG document
                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        // Create ImageSaveOptions for GIF with custom settings
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                        options.UseAntialiasing = true;
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;
                        options.BackgroundColor = Color.White;

                        // Convert SVG to GIF
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