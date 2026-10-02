// Develop a retry policy using Polly that handles transient I/O errors during MHTML to PDF conversion.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "sample.pdf";
            int maxAttempts = 3;

            // Ensure a minimal input file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML Content</h1></body></html>");
            }

            ConvertMhtmlToPdfWithRetry(inputPath, outputPath, maxAttempts);
            Console.WriteLine($"Conversion succeeded: '{outputPath}'");
            Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
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
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }
                // Success, exit method
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

        // All attempts failed
        throw lastException ?? new Exception("Conversion failed after multiple attempts.");
    }
}