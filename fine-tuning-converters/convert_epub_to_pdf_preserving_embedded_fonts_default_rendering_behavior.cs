// Convert an EPUB document to PDF while preserving embedded fonts through default rendering behavior.

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
            string inputPath = "sample.epub";
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "result.pdf");

            Directory.CreateDirectory(outputDirectory);

            using (Stream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB to PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}