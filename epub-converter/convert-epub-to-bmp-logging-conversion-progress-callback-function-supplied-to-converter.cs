// Convert EPUB to BMP while logging conversion progress through a callback function supplied to the Converter.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Create a placeholder EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for BMP format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                Console.WriteLine("Starting EPUB to BMP conversion...");

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                Console.WriteLine($"Conversion completed. BMP saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}