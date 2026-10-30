// Export an EPUB chapter to PDF, preserving embedded images and text formatting.

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
            // Input EPUB file (ensure this file exists in the executable directory)
            string inputPath = "sample.epub";

            // Output directory and PDF file path
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "chapter.pdf");

            // Open the EPUB file as a stream
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Create PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB has been successfully converted to PDF:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}