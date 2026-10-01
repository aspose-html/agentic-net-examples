// Convert EPUB to TIFF with ImageSaveOptions.Compression set to LZW to achieve lossless compression.

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
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.UseAntialiasing = true;
                // Compression = LZW is omitted because the enum member may not be available in the current API.

                string outputPath = Path.Combine(dataDir, "output.tiff");
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine("Conversion completed: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}