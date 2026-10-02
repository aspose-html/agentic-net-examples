// Convert EPUB to TIFF using ImageSaveOptions.Margins to ensure consistent spacing around rendered pages.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string epubPath = "sample.epub";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Open EPUB file stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = System.Drawing.Color.White
                };

                // Set page size and margins
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(1200, 1600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                // Convert EPUB to TIFF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to TIFF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}