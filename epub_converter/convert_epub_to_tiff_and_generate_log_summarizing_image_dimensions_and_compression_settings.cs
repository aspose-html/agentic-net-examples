// Convert EPUB to TIFF and generate a detailed log entry summarizing image dimensions and compression settings.

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
            // Input EPUB file stream
            using (FileStream stream = File.OpenRead("input.epub"))
            {
                // Output TIFF file path
                string outputPath = "output.tiff";

                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    Compression = Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 400,
                    VerticalResolution = 400,
                    BackgroundColor = System.Drawing.Color.White
                };

                // Set page size and margins
                options.PageSetup.AnyPage = new Page(
                    new Size(800, 500),
                    new Margin(30, 20, 10, 10)
                );

                // Perform conversion
                Converter.ConvertEPUB(stream, options, outputPath);

                // Log conversion details
                var pageSize = options.PageSetup.AnyPage.Size;
                Console.WriteLine($"TIFF conversion completed.");
                Console.WriteLine($"Image dimensions: {pageSize.Width}x{pageSize.Height} points");
                Console.WriteLine($"Resolution: {options.HorizontalResolution}x{options.VerticalResolution} DPI");
                Console.WriteLine($"Compression: {options.Compression}");
                Console.WriteLine($"Output file: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}