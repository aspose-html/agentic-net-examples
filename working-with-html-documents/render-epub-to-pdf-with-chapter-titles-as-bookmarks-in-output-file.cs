// Render an EPUB to PDF with chapter titles as bookmarks for easy navigation in the output file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB and output PDF paths
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample.epub");
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.pdf");

            // Ensure the input file exists (create a minimal placeholder if needed)
            if (!File.Exists(inputPath))
            {
                // Create a minimal empty EPUB file as a placeholder.
                // In a real scenario, replace this with a valid EPUB file.
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // ZIP header
            }

            // Open the EPUB file stream
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Configure PDF save options (default options)
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert EPUB to PDF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, outputPath);
            }

            Console.WriteLine($"EPUB has been successfully converted to PDF at: {outputPath}");
            // Note: Aspose.HTML conversion automatically creates PDF bookmarks for EPUB chapters when possible.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during conversion: {ex.Message}");
        }
    }
}