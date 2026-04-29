// Validate that the output PDF file exists and its size exceeds a minimum threshold after conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string pdfPath = Path.Combine(baseDir, "output.pdf");

            // Create a simple HTML file
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Set PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert HTML to PDF
            Converter.ConvertHTML(htmlPath, options, pdfPath);

            // Verify the PDF file exists and is not empty
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException("PDF file was not created.", pdfPath);

            FileInfo info = new FileInfo(pdfPath);
            if (info.Length == 0)
                throw new InvalidDataException("PDF file is empty.");

            Console.WriteLine("Conversion verification passed. PDF file created at: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}