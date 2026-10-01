// Render an MHTML email archive to PDF while preserving embedded images and styles.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Ensure a minimal MHTML file exists
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Open the MHTML file for reading
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine($"Conversion succeeded. PDF saved to: {outputPath}");
            Console.WriteLine("Note: Extracting text from the PDF requires a separate PDF parsing library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}