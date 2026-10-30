// Convert EPUB to TIFF using ImageSaveOptions.PageSize to enforce exact page dimensions during rendering.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (ensure the file exists)
            string inputPath = "sample.epub";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Open the EPUB file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = Color.White
                };

                // Define exact page size (e.g., 800x1000 pixels) with zero margins
                var page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1000),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                options.PageSetup.AnyPage = page;

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to TIFF at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}