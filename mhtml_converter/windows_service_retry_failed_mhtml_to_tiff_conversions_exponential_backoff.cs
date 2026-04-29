// Develop a Windows service that retries failed MHTML to TIFF conversions using an exponential backoff strategy.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Example input and output paths; replace with actual paths as needed.
            string inputPath = "input.mhtml";
            string outputPath = "output.tiff";
            int maxRetryAttempts = 5;

            ConvertMhtmlToTiffWithRetry(inputPath, outputPath, maxRetryAttempts);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }

    static void ConvertMhtmlToTiffWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        int baseDelayMilliseconds = 500; // Initial delay for backoff

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                // Open a fresh stream for each attempt
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Configure image save options for TIFF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    // Perform the conversion
                    Converter.ConvertMHTML(stream, options, outputPath);
                }

                // If conversion succeeds, exit the method
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

            // If this was not the last attempt, wait using exponential backoff
            if (attempt < maxAttempts)
            {
                int delay = baseDelayMilliseconds * (int)Math.Pow(2, attempt - 1);
                Thread.Sleep(delay);
            }
        }

        // After all attempts have failed, rethrow the last captured exception
        throw lastException ?? new Exception("Unknown error during conversion.");
    }
}