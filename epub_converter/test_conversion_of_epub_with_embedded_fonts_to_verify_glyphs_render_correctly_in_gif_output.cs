// Test conversion of an EPUB with embedded fonts to verify glyphs render correctly in the GIF output.

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
            // Path to the EPUB file that contains embedded fonts
            string inputPath = "input.epub";

            // Desired output GIF file path
            string outputPath = "output.gif";

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image saving options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Convert the EPUB stream to a GIF image
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