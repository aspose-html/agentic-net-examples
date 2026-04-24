// Convert EPUB to TIFF with ImageSaveOptions.Compression set to LZW to achieve lossless compression.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string epubPath = "input.epub";
                string outputPath = "output.tiff";

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    Converter.ConvertEPUB(stream, options, outputPath);
                }

                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}