// Convert EPUB to JPEG with ImageSaveOptions.DpiX and DpiY set to 300 for high‑resolution output.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "sample.jpg");

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}