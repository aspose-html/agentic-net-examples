// Batch process multiple EPUB files to PNG images by programmatically invoking Converter.ConvertEPUB for each entry.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputPngs";
            Directory.CreateDirectory(outputDir);
            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    string fileName = Path.GetFileNameWithoutExtension(epubPath);
                    string outputPath = Path.Combine(outputDir, fileName + ".png");
                    Converter.ConvertEPUB(stream, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}