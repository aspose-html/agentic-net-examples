// Convert a DRM‑free EPUB to PNG while handling potential encryption exceptions during the conversion process.

using System;
using System.IO;
using Aspose.Html.Saving;
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
                // Create an empty placeholder EPUB file (for demonstration purposes)
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                string outputPath = Path.Combine(outputDir, "output.png");
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                Console.WriteLine("Conversion completed: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during EPUB to PNG conversion: " + ex.Message);
        }
    }
}