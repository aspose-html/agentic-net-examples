// Convert an EPUB file to DOCX ensuring the output directory exists before writing the file.

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
            string sourcePath = "input.epub";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "output.docx");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            DocSaveOptions options = new DocSaveOptions();
            Converter.ConvertEPUB(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}