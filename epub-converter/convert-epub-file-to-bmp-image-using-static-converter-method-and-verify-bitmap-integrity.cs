// Convert an EPUB file to BMP image using the static Converter method and verify bitmap integrity.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample.epub");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.bmp");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input EPUB file not found: " + inputPath);
                return;
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            if (File.Exists(outputPath))
            {
                using (Bitmap bmp = new Bitmap(outputPath))
                {
                    Console.WriteLine($"Bitmap saved successfully. Width: {bmp.Width}, Height: {bmp.Height}");
                }
            }
            else
            {
                Console.WriteLine("Conversion failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}