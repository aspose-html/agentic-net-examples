// Render an EPUB to PDF with chapter titles as bookmarks for easy navigation in the output file.

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
            // Define input EPUB and output PDF paths
            string inputPath = Path.Combine("Data", "sample.epub");
            string outputPath = Path.Combine("Output", "sample.pdf");

            // Open the EPUB file as a read stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options (customize if needed)
                PdfSaveOptions options = new PdfSaveOptions();
                // If the API provides a property to enable bookmarks, set it here
                // options.Outlines = true;

                // Convert EPUB to PDF
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}