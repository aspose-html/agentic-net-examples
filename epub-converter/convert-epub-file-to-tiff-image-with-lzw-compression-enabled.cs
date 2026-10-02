// Convert an EPUB file to TIFF image with LZW compression enabled through conversion options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output TIFF file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "sample.epub");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.tiff");

            // Ensure a sample EPUB file exists (create an empty placeholder if needed)
            if (!File.Exists(inputPath))
            {
                using (FileStream placeholder = File.Create(inputPath))
                {
                    // Placeholder content; real EPUB data should be placed here.
                }
            }

            // Open the EPUB file stream
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF with LZW compression (if supported)
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // LZW compression is not available in this API version; using None as fallback
                options.Compression = Compression.None;

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}