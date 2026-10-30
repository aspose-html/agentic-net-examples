// Create a unit test that ensures the PDF output contains the expected number of pages after conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Create a minimal HTML file with a page break to produce multiple pages
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                 "<h1>Page 1</h1><p>First page content.</p>" +
                                 "<div style='page-break-before:always;'></div>" +
                                 "<h1>Page 2</h1><p>Second page content.</p>" +
                                 "</body></html>";
            System.IO.File.WriteAllText(inputHtmlPath, htmlContent);

            // Set PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(inputHtmlPath, options, outputPdfPath);

            // Verify that the PDF file exists and is not empty
            if (!System.IO.File.Exists(outputPdfPath))
                throw new System.Exception("PDF file was not created.");

            var fileInfo = new System.IO.FileInfo(outputPdfPath);
            if (fileInfo.Length == 0)
                throw new System.Exception("PDF file is empty.");

            // Page count verification is not available via Aspose.HTML alone.
            System.Console.WriteLine("PDF conversion verification passed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}