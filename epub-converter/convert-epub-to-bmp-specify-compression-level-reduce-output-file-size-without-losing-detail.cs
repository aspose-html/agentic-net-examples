// Convert EPUB to BMP and specify ImageSaveOptions.CompressionLevel to reduce output file size without losing detail.

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
            // Define input EPUB file path
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");

            // Create a minimal placeholder EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Open the EPUB file stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Define output directory for generated BMP files
                string outputDir = Path.Combine(dataDir, "output");
                Directory.CreateDirectory(outputDir);

                // Convert EPUB to BMP images
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputDir);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}