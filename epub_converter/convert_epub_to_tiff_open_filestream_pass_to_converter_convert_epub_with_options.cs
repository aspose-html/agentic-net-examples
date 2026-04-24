// Convert EPUB to TIFF by opening a FileStream and passing it to Converter.ConvertEPUB with options.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace EpubToTiff
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source EPUB file
                string epubPath = "sample.epub";
                // Desired output TIFF file path
                string tiffPath = "sample.tiff";

                // Open the EPUB file as a readable stream
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Configure image save options for TIFF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                    // Convert the EPUB stream to a TIFF image file
                    Converter.ConvertEPUB(epubStream, options, tiffPath);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }
    }
}