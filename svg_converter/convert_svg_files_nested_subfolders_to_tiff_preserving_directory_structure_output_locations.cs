// Convert SVG files located in nested subfolders to TIFF, preserving directory structure in output locations.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Input folder containing SVG files (including subfolders)
            string inputFolder = @"C:\InputSvg";
            // Output folder where TIFF files will be saved, preserving structure
            string outputFolder = @"C:\OutputTiff";

            // Ensure the output root folder exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get all SVG files recursively
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.AllDirectories);

            foreach (string svgPath in svgFiles)
            {
                // Determine relative path to recreate directory structure
                string relativePath = Path.GetRelativePath(inputFolder, svgPath);
                string outputDir = Path.Combine(outputFolder, Path.GetDirectoryName(relativePath));

                // Create the output subdirectory if it does not exist
                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                // Build the output TIFF file path
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string tiffPath = Path.Combine(outputDir, fileName + ".tiff");

                // Configure image save options for TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                // Convert SVG to TIFF
                Converter.ConvertSVG(svgPath, options, tiffPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}