// Implement a retry mechanism that attempts MHTML to XPS conversion up to three times on failure.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        string inputPath = "input.mhtml";
        string outputPath = "output.xps";

        try
        {
            ConvertMhtmlToXpsWithRetry(inputPath, outputPath, 3);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }

    static void ConvertMhtmlToXpsWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                // Open a fresh stream for each attempt
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Default XPS save options
                    XpsSaveOptions options = new XpsSaveOptions();

                    // Perform the conversion
                    Converter.ConvertMHTML(stream, options, outputPath);
                }

                // If conversion succeeds, exit the method
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

            // If not the last attempt, wait before retrying
            if (attempt < maxAttempts)
            {
                Thread.Sleep(1000); // wait 1 second
            }
        }

        // All attempts failed; rethrow the last captured exception
        throw lastException;
    }
}