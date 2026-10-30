// Validate that the output PDF file exists and its size exceeds a minimum threshold after conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Set PDF save options
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, pdfOptions, outputPath);

            // Verify the output PDF
            if (!File.Exists(outputPath))
                throw new Exception("Output PDF file does not exist.");

            var info = new FileInfo(outputPath);
            if (info.Length == 0)
                throw new Exception("Output PDF file is empty.");

            Console.WriteLine("PDF conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}