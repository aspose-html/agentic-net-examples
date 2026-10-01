// Add error handling to catch Converter.ConvertHTML exceptions and log conversion failures for diagnostics.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "";
            string htmlToPdfPath = "output_html_to_pdf.pdf";

            // Convert HTML string to PDF
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, pdfOptions, htmlToPdfPath);
            Console.WriteLine($"HTML successfully converted to PDF: {htmlToPdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HTML to PDF conversion failed: {ex.Message}");
        }

        // Example of converting MHTML to PDF with retry logic
        string mhtmlInputPath = "sample.mhtml";
        string mhtmlToPdfPath = "output_mhtml_to_pdf.pdf";

        // Create a minimal MHTML file for demonstration purposes
        if (!File.Exists(mhtmlInputPath))
        {
            File.WriteAllText(mhtmlInputPath, "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><p>Sample MHTML content.</p></body></html>\r\n------=_NextPart_000_0000--");
        }

        try
        {
            ConvertMhtmlToPdfWithRetry(mhtmlInputPath, mhtmlToPdfPath, 3);
            Console.WriteLine($"MHTML successfully converted to PDF: {mhtmlToPdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"MHTML to PDF conversion failed after retries: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                // Success, exit the method
                return;
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            // Wait before next retry
            Thread.Sleep(1000);
        }

        // After all attempts, rethrow the last captured exception
        throw lastException ?? new Exception("Unknown error during MHTML to PDF conversion.");
    }
}