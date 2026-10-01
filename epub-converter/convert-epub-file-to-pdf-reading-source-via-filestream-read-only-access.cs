// Convert an EPUB file to PDF by reading the source via FileStream with read‑only access.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine($"EPUB successfully converted to PDF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}