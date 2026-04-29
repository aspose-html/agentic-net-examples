// Measure conversion time for converting 100 SVG files to BMP using a stopwatch and log results.

using System;
using System.Diagnostics;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using System.Drawing;

namespace SvgBatchConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output folders
                string inputFolder = "InputSvgs";
                string outputFolder = "OutputBmps";

                // Ensure output folder exists
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Get all SVG files from the input folder
                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
                int total = svgFiles.Length;

                // Start measuring conversion time
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Process each SVG file
                for (int i = 0; i < total; i++)
                {
                    string svgPath = svgFiles[i];
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(svgPath) + ".bmp");

                    // Load SVG document
                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        // Configure image save options
                        ImageSaveOptions options = new ImageSaveOptions();
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;
                        options.BackgroundColor = Color.White;
                        options.UseAntialiasing = true;

                        // Convert SVG to BMP
                        Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                    }

                    // Report progress
                    int percent = (i + 1) * 100 / total;
                    Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
                }

                // Stop timing and log total duration
                stopwatch.Stop();
                Console.WriteLine($"Total conversion time for {total} files: {stopwatch.Elapsed}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}