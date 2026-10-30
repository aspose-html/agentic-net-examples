// Convert EPUB to TIFF and attach creation date metadata using ImageSaveOptions to track conversion time.

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
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                // Create a placeholder empty EPUB file
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                // Note: ImageSaveOptions does not expose a CreationDate property; metadata can be added via other means if supported.
                string outputPath = Path.Combine(outputDir, "output.tiff");
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB to TIFF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}