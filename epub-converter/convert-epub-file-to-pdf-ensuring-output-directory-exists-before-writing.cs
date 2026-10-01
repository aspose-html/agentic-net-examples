// Convert an EPUB file to PDF ensuring the output directory exists before writing the file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "result.pdf");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the EPUB file stream
            using (Stream epubStream = File.OpenRead(sourcePath))
            {
                // Create PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}