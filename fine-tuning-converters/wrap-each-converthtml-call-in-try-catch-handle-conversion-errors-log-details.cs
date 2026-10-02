// Wrap each ConvertHTML call in a try‑catch block to handle conversion errors and log details.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content conversion to MHTML
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            string mhtmlOutputPath = "sample.mhtml";

            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();

            try
            {
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, mhtmlOptions, mhtmlOutputPath);
                Console.WriteLine($"MHTML conversion succeeded: {mhtmlOutputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MHTML conversion failed: {ex.Message}");
            }

            // Convert the generated MHTML to PDF with retry logic
            string pdfOutputPath = "sample.pdf";
            try
            {
                ConvertMhtmlToPdfWithRetry(mhtmlOutputPath, pdfOutputPath, 3);
                Console.WriteLine($"PDF conversion succeeded: {pdfOutputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PDF conversion failed after retries: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
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
                }
                // Success, exit method
                return;
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
                Console.WriteLine($"Attempt {attempt} failed with IOException: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
                Console.WriteLine($"Attempt {attempt} failed with UnauthorizedAccessException: {uaEx.Message}");
            }

            // Wait before next retry
            Thread.Sleep(1000);
        }

        // All attempts failed, rethrow the last exception
        throw lastException ?? new Exception("Conversion failed without captured exception.");
    }
}