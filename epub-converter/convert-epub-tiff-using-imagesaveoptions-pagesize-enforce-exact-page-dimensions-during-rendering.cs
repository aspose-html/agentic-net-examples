// Convert EPUB to TIFF using ImageSaveOptions.PageSize to enforce exact page dimensions during rendering.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Ensure the input file exists (create a minimal placeholder if not)
            if (!File.Exists(inputPath))
            {
                // Create an empty EPUB file as a placeholder (real EPUB content required for actual conversion)
                using (FileStream fs = File.Create(inputPath))
                {
                    // Write minimal EPUB header bytes (optional)
                }
            }

            // Open the EPUB file stream
            Stream stream = File.OpenRead(inputPath);

            // Configure image save options for TIFF with exact page size
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
            {
                Compression = Compression.None,
                UseAntialiasing = true,
                HorizontalResolution = 300,
                VerticalResolution = 300,
                BackgroundColor = System.Drawing.Color.White
            };

            // Set exact page dimensions (e.g., 800x1200 pixels) with zero margins
            options.PageSetup.AnyPage = new Page(
                new Size(800, 1200),
                new Margin(0, 0, 0, 0)
            );

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

            // Cleanup
            stream.Dispose();

            Console.WriteLine("EPUB has been successfully converted to TIFF at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}