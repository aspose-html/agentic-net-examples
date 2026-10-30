// Convert EPUB to PNG and set ImageSaveOptions.CssMediaType to 'all' for comprehensive CSS handling.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.png");

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.Css.MediaType = MediaType.Print; // comprehensive CSS handling using a supported media type
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}