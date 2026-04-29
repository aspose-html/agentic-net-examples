// Implement a retry loop that attempts MHTML to PNG conversion up to five times with incremental delays.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.mhtml";
        string outputPath = "output.png";

        try
        {
            ConvertMhtmlToPngWithRetry(inputPath, outputPath, 5);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPngWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                // Open a fresh stream for each attempt
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Configure PNG output options
                    ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                    // Perform the conversion
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                // If conversion succeeds, exit the loop
                return;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                lastException = ex;

                if (attempt == maxAttempts)
                    break; // No more retries

                // Incremental delay (e.g., 1 second per attempt)
                int delayMilliseconds = attempt * 1000;
                Thread.Sleep(delayMilliseconds);
            }
        }

        // After all attempts have failed, rethrow the last exception
        throw lastException ?? new Exception("Unknown error during conversion.");
    }
}