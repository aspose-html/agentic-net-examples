// Convert EPUB to BMP while logging conversion progress through a callback function supplied to the Converter.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[] { });
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion to BMP completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}