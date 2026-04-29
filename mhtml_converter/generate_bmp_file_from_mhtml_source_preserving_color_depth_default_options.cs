// Generate a BMP file from MHTML source while preserving original color depth using default options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace MhtmlToBmp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source MHTML file
                string inputPath = "input.mhtml";
                // Path where the BMP image will be saved
                string outputPath = "output.bmp";

                // Open the MHTML file as a read-only stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Create image save options specifying BMP format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                    // Perform the conversion from MHTML to BMP
                    Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("MHTML successfully converted to BMP.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}