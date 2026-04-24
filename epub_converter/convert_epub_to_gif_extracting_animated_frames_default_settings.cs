// Convert an EPUB file to GIF image extracting animated frames if present using default settings.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string inputPath = "input.epub";

            // Path where the resulting GIF will be saved
            string outputPath = "output.gif";

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Convert the EPUB to a GIF image
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}