// Render an EPUB document to PDF, preserving chapter hierarchy and table of contents.

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
            string inputPath = "input.epub";
            string outputPath = "output.pdf";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}