// Batch process multiple EPUB files to PNG images by programmatically invoking Converter.ConvertEPUB for each entry.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "InputEpubs";
            string outputDir = "OutputImages";

            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(dataDir, "*.epub");
            if (epubFiles.Length == 0)
            {
                Console.WriteLine("No EPUB files found in the input directory.");
                return;
            }

            foreach (string epubPath in epubFiles)
            {
                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions();

                    string baseName = Path.GetFileNameWithoutExtension(epubPath);
                    string outPath = Path.Combine(outputDir, baseName);
                    Directory.CreateDirectory(outPath);

                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outPath);
                    Console.WriteLine($"Converted '{epubPath}' to images in '{outPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}