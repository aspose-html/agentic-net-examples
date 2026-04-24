// Load an MHTML file and convert it to PNG format, extracting embedded images automatically.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace MhtmlToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source MHTML file
                string inputPath = "input.mhtml";

                // Path where the PNG image will be saved
                string outputPath = "output.png";

                // Open the MHTML file as a stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Configure image saving options for PNG format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                    // Convert the MHTML content to a PNG image
                    Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("MHTML successfully converted to PNG.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}