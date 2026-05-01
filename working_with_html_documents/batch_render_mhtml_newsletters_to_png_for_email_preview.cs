// Batch render a set of MHTML newsletters to PNG images for email preview generation.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace BatchMhtmlToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input folder containing MHTML newsletters
                string inputFolder = args.Length > 0 ? args[0] : "./newsletters";
                // Output folder for generated PNG previews
                string outputFolder = args.Length > 1 ? args[1] : "./previews";

                // Ensure output directory exists
                Directory.CreateDirectory(outputFolder);

                // Get all MHTML files in the input folder
                string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mhtml");

                foreach (string mhtmlPath in mhtmlFiles)
                {
                    try
                    {
                        // Open MHTML file as a read-only stream
                        using Stream stream = File.OpenRead(mhtmlPath);

                        // Determine output PNG file path
                        string outputPath = Path.Combine(
                            outputFolder,
                            Path.GetFileNameWithoutExtension(mhtmlPath) + ".png");

                        // Configure image save options for PNG format
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                        // Convert MHTML stream to PNG image
                        Converter.ConvertMHTML(stream, options, outputPath);

                        Console.WriteLine($"Converted: {mhtmlPath} -> {outputPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{mhtmlPath}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
            }
        }
    }
}