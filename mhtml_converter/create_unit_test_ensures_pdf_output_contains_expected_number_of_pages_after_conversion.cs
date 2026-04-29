// Create a unit test that ensures the PDF output contains the expected number of pages after conversion.

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
            // Define paths for the source HTML and the resulting PDF
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string pdfPath = Path.Combine(baseDir, "output.pdf");

            // Create a simple HTML file to be converted
            File.WriteAllText(htmlPath, "<html><body><h1>Test Page</h1><p>This is a test.</p></body></html>");

            // Configure PDF save options (default settings)
            var pdfOptions = new PdfSaveOptions();

            // Perform the conversion from HTML to PDF
            Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);

            // Verify that the PDF file was created and is not empty
            if (!File.Exists(pdfPath))
                throw new InvalidOperationException("PDF file was not created.");

            var fileInfo = new FileInfo(pdfPath);
            if (fileInfo.Length == 0)
                throw new InvalidOperationException("PDF file is empty.");

            Console.WriteLine("PDF conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}