// Convert EPUB to TIFF using ImageSaveOptions.Margins to ensure consistent spacing around rendered pages.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string inputPath = "sample.epub";

            // Desired output TIFF file path
            string outputPath = "output.tiff";

            // Open the EPUB file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create ImageSaveOptions for TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                // Configure rendering options
                options.Compression = Compression.None;          // No compression
                options.UseAntialiasing = true;                 // Enable antialiasing
                options.HorizontalResolution = 400;             // 400 DPI horizontal
                options.VerticalResolution = 400;               // 400 DPI vertical

                // Set page size and margins to ensure consistent spacing
                options.PageSetup.AnyPage = new Page(
                    new Size(800, 500),                         // Page size: 800x500 points
                    new Margin(30, 20, 10, 10)                  // Margins: top, right, bottom, left
                );

                // Perform the conversion from EPUB to TIFF
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to TIFF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}