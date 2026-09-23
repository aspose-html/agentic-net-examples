// Convert EPUB to TIFF and generate a detailed log entry summarizing image dimensions and compression settings.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (replace with a valid EPUB file path)
            string inputPath = "sample.epub";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Open EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                    Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = System.Drawing.Color.White
                };

                // Set page size and margins
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(2480, 3508), // A4 at 300 DPI
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));
                options.PageSetup.AnyPage = page;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            // Log conversion details
            Console.WriteLine("EPUB to TIFF conversion completed.");
            Console.WriteLine($"Output file: output.tiff");
            Console.WriteLine($"Image format: TIFF");
            Console.WriteLine($"Compression: None");
            Console.WriteLine($"Horizontal Resolution: 300 DPI");
            Console.WriteLine($"Vertical Resolution: 300 DPI");
            Console.WriteLine($"Page size: 2480 x 3508 pixels");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}