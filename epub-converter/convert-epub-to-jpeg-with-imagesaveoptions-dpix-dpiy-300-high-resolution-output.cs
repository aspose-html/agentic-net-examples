// Convert EPUB to JPEG with ImageSaveOptions.DpiX and DpiY set to 300 for high‑resolution output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output JPEG file paths
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample.epub");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.jpg");

            // Ensure the input file exists (create a minimal placeholder if needed)
            if (!File.Exists(inputPath))
            {
                // Create a minimal empty EPUB file for demonstration purposes
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // ZIP header
            }

            // Configure image save options with high resolution
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.UseAntialiasing = true;

            // Perform the conversion
            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}