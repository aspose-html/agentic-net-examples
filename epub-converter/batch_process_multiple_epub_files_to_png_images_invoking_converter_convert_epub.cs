// Batch process multiple EPUB files to PNG images by programmatically invoking Converter.ConvertEPUB for each entry.

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
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(dataDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                string epubOutputDir = Path.Combine(outputDir, fileNameWithoutExt);
                Directory.CreateDirectory(epubOutputDir);

                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, epubOutputDir);
                }

                Console.WriteLine($"Converted '{epubPath}' to images in '{epubOutputDir}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}