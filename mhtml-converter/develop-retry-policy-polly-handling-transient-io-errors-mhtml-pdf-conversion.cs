// Develop a retry policy using Polly that handles transient I/O errors during MHTML to PDF conversion.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";
            int maxAttempts = 3;

            // Ensure a minimal MHTML file exists
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body><h1>Hello, MHTML!</h1></body>
</html>";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            ConvertMhtmlToPdfWithRetry(inputPath, outputPath, maxAttempts);
            Console.WriteLine($"PDF successfully created at '{outputPath}'.");
            Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library if such a library is not available in the current project.");
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
                    var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }

                Console.WriteLine($"Conversion succeeded on attempt {attempt}.");
                return;
            }
            catch (IOException ex)
            {
                lastException = ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                lastException = ex;
            }

            if (attempt < maxAttempts)
            {
                // Wait before retrying
                Thread.Sleep(1000);
            }
        }

        // All attempts failed
        throw lastException;
    }
}