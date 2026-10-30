// Convert a list of EPUB file paths to DOCX using a reusable method that accepts save options.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            var epubFiles = new List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            var options = new Aspose.Html.Saving.DocSaveOptions();

            foreach (var epubPath in epubFiles)
            {
                string outputDirectory = Path.GetDirectoryName(epubPath) ?? string.Empty;
                string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".docx";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                ConvertEpubToDocx(epubPath, options, outputPath);
                Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertEpubToDocx(string sourcePath, Aspose.Html.Saving.DocSaveOptions options, string outputPath)
    {
        Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);
    }
}