// Generate a multi‑page TIFF from a single MHTML file by setting ImageSaveOptions multipage flag.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace MhtmlToMultiPageTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source MHTML file
                string inputPath = "input.mhtml";

                // Path for the resulting TIFF file
                string outputPath = "output.tiff";

                // Open a readable stream for the MHTML document
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Create image save options for TIFF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                    // Optional: improve rendering quality
                    options.UseAntialiasing = true;

                    // Convert the MHTML stream to a TIFF image
                    Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("MHTML successfully converted to TIFF.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}