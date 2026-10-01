// Convert an EPUB document to TIFF image by invoking Converter.ConvertEPUB with no custom options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}