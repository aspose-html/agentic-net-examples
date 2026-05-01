// Batch render SVG icons to PNG at 64 px and 128 px sizes for different device densities.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input folder containing SVG icons
            string inputFolder = "input_svgs";
            // Output folder for generated PNGs
            string outputFolder = "output_pngs";

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            // Process each SVG file
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);

                // Render at two different pixel sizes: 64 px and 128 px
                foreach (int size in new int[] { 64, 128 })
                {
                    string outputPath = Path.Combine(outputFolder, $"{fileNameWithoutExt}_{size}.png");

                    // Load SVG document
                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        // Configure image save options
                        ImageSaveOptions options = new ImageSaveOptions();
                        options.HorizontalResolution = size;   // Approximate pixel size via DPI
                        options.VerticalResolution = size;
                        options.BackgroundColor = Color.White;
                        options.UseAntialiasing = true;

                        // Convert SVG to PNG
                        Converter.ConvertSVG(document, options, outputPath);
                    }
                }

                // Report progress
                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(svgPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}