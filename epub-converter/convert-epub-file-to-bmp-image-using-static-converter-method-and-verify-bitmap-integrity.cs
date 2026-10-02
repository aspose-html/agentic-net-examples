// Convert an EPUB file to BMP image using the static Converter method and verify bitmap integrity.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            if (!File.Exists(outputPath))
            {
                Console.WriteLine("Conversion failed: output file not created.");
                return;
            }

            using (Bitmap bitmap = new Bitmap(outputPath))
            {
                if (bitmap.Width > 0 && bitmap.Height > 0)
                {
                    Console.WriteLine($"Bitmap created successfully. Dimensions: {bitmap.Width}x{bitmap.Height}");
                }
                else
                {
                    Console.WriteLine("Bitmap has invalid dimensions.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}