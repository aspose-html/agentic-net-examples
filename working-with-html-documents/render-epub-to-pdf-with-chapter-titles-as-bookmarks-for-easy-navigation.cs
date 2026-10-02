// Render an EPUB to PDF with chapter titles as bookmarks for easy navigation in the output file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (replace with actual path if needed)
            string inputPath = "sample.epub";

            // Output PDF file path
            string outputPath = Path.Combine("output", "result.pdf");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}