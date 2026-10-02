// Render an EPUB document to PDF, preserving chapter hierarchy and table of contents.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output PDF file paths
            string inputPath = "sample.epub";
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "sample.pdf");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the EPUB file stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Create PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}