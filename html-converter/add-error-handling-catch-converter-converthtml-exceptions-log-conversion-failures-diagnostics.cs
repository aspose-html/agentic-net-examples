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
            // Convert HTML to MHTML with error handling
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            string mhtmlOutput = "sample.mhtml";
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();

            try
            {
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, mhtmlOptions, mhtmlOutput);
                Console.WriteLine($"HTML converted to MHTML successfully: {mhtmlOutput}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to convert HTML to MHTML: {ex.Message}");
            }

            // Convert MHTML to PDF with retry logic
            string pdfOutput = "sample.pdf";
            ConvertMhtmlToPdfWithRetry(mhtmlOutput, pdfOutput, 3);
            Console.WriteLine($"MHTML converted to PDF successfully: {pdfOutput}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
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
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                    return; // Success
                }
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            // Wait before next attempt
            Thread.Sleep(1000);
        }

        // After all attempts, rethrow the last captured exception
        throw lastException ?? new Exception("Conversion failed after all retry attempts.");
    }
}