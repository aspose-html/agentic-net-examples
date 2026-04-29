// Configure ImageSaveOptions to set compression level for BMP output when converting MHTML files.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source MHTML file
            string inputPath = "input.mhtml";

            // Desired output BMP file path
            string outputPath = "output.bmp";

            // Open a readable stream for the MHTML source
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create ImageSaveOptions with BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Note: CompressionLevel is not supported for BMP in Aspose.HTML, so it is omitted.

                // Convert the MHTML stream to a BMP image
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to BMP.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}