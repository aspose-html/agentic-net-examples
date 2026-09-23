// Convert EPUB to BMP and specify ImageSaveOptions.CompressionLevel to reduce output file size without losing detail.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.bmp");

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to BMP: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}