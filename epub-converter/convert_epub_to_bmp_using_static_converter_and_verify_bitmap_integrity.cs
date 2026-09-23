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
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "sample.bmp");

            if (!File.Exists(epubPath))
            {
                Console.WriteLine($"EPUB file not found at {epubPath}. Please provide a valid EPUB file.");
                return;
            }

            using (Stream stream = File.OpenRead(epubPath))
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
                Console.WriteLine("Conversion failed: output file not created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}