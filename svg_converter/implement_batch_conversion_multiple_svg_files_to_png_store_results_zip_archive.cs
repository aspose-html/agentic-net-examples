// Implement batch conversion of multiple SVG files to PNG and store results in a zip archive.

using System;
using System.IO;
using System.Drawing;
using System.IO.Compression;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputPngs";

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files from the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            // Process each SVG file
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".png");

                // Load SVG document
                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    // Configure image save options
                    ImageSaveOptions options = new ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;

                    // Convert SVG to PNG
                    Converter.ConvertSVG(document, options, outputPath);
                }

                // Report progress
                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // Create a zip archive containing all PNG files
            string zipPath = Path.Combine(outputFolder, "SvgsToPng.zip");
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(outputFolder, zipPath);
            Console.WriteLine($"All PNG files zipped to {zipPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}