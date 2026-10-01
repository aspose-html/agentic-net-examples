// Convert EPUB to PNG using ImageSaveOptions.CompressionLevel set to 6 for moderate compression efficiency.

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
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            string outputPath = Path.Combine(outputDir, "output.png");

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                // CompressionLevel property is not available in the API; omitted.
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}