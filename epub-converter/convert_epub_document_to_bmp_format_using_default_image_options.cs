// Convert an EPUB document to BMP format by calling Converter.ConvertEPUB with default image options.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion to BMP completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}