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

            // Create placeholder EPUB files if they do not exist
            foreach (var path in epubFiles)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, new byte[0]);
                }
            }

            var options = new Aspose.Html.Saving.DocSaveOptions();

            foreach (var epubPath in epubFiles)
            {
                string outputPath = Path.ChangeExtension(epubPath, ".docx");
                ConvertEpubToDocx(epubPath, outputPath, options);
                Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertEpubToDocx(string sourcePath, string outputPath, Aspose.Html.Saving.DocSaveOptions options)
    {
        Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);
    }
}