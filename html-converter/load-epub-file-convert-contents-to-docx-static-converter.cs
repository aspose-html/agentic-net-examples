// Load an EPUB file and convert its contents to DOCX using the static Converter class.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "sample.docx";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Input file '{sourcePath}' not found.");
                return;
            }

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine($"EPUB converted to DOCX successfully: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}