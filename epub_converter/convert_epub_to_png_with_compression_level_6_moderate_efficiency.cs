// Convert EPUB to PNG using ImageSaveOptions.CompressionLevel set to 6 for moderate compression efficiency.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            string pngPath = Path.Combine(outputDir, "output.png");

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                Converter.ConvertEPUB(stream, options, pngPath);
            }

            Console.WriteLine("EPUB converted to PNG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}