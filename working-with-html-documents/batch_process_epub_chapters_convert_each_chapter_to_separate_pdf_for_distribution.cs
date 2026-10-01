// Batch process EPUB chapters, converting each chapter to a separate PDF file for distribution.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (replace with an existing EPUB file if needed)
            string inputPath = "sample.epub";

            // Output PDF file path
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "result.pdf");
            Directory.CreateDirectory(outputDirectory);

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the EPUB file stream
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Create PDF save options
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"EPUB successfully converted to PDF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}