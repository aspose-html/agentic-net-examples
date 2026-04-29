// Batch convert SVG files to TIFF, configuring Compression property differently for each output file.

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
            // Define input and output folders
            string inputFolder = @"C:\InputSvg";
            string outputFolder = @"C:\OutputTiff";

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
                    Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                // Load SVG document
                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    // Create TIFF save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    options.HorizontalResolution = 200;
                    options.VerticalResolution = 200;

                    // Choose compression based on file index
                    switch (i % 5)
                    {
                        case 0:
                            options.Compression = Compression.LZW;
                            break;
                        case 1:
                            options.Compression = Compression.CCITT3;
                            break;
                        case 2:
                            options.Compression = Compression.CCITT4;
                            break;
                        case 3:
                            options.Compression = Compression.Rle;
                            break;
                        default:
                            options.Compression = Compression.None;
                            break;
                    }

                    // Convert SVG to TIFF
                    Converter.ConvertSVG(document, options, outputPath);
                }

                Console.WriteLine($"Converted {i + 1}/{total}: {Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}