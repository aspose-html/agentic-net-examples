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
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";
            ConvertMhtmlToPdfWithRetry(inputPath, outputPath, 3);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
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
                    PdfSaveOptions options = new PdfSaveOptions();
                    Converter.ConvertMHTML(stream, options, outputPath);
                }
                return;
            }
            catch (IOException) when (attempt < maxAttempts)
            {
                lastException = new IOException($"Attempt {attempt} failed.", lastException);
                Thread.Sleep(1000);
            }
            catch (UnauthorizedAccessException) when (attempt < maxAttempts)
            {
                lastException = new UnauthorizedAccessException($"Attempt {attempt} failed.", lastException);
                Thread.Sleep(1000);
            }
        }
        throw lastException ?? new Exception("Conversion failed after retries.");
    }
}