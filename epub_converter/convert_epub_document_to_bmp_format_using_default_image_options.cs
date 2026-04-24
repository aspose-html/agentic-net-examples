// Convert an EPUB document to BMP format by calling Converter.ConvertEPUB with default image options.

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
            string epubPath = "input.epub";

            // Path where the BMP image will be saved
            string outputPath = "output.bmp";

            // Open the EPUB file as a readable stream
            using (Stream stream = File.OpenRead(epubPath))
            {
                // Create image save options with BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert the EPUB to BMP using the Aspose.HTML Converter
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to BMP.");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}