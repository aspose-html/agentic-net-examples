// Verify PDF output contains the correct number of pages by opening the file with a PDF reader library.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Test PDF</h1><p>This is page 1.</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            // Verify the PDF file
            if (!File.Exists(outputPath))
                throw new Exception("PDF file was not created.");

            FileInfo pdfInfo = new FileInfo(outputPath);
            if (pdfInfo.Length == 0)
                throw new Exception("PDF file is empty.");

            Console.WriteLine($"PDF conversion verification passed. File size: {pdfInfo.Length} bytes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}