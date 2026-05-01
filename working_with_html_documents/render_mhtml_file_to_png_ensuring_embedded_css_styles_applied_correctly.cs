// Render an MHTML file to PNG, ensuring embedded CSS styles are applied correctly.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace MhtmlToPngExample
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
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Configure image save options for PNG format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                    // Convert the MHTML content to a PNG image
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}