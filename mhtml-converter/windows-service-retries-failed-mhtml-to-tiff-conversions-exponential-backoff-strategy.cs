// Develop a Windows service that retries failed MHTML to TIFF conversions using an exponential backoff strategy.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.tiff";
            int maxAttempts = 5;

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!-- Sample MHTML content -->");
            }

            ConvertMhtmlToTiffWithRetry(inputPath, outputPath, maxAttempts);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToTiffWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        int delayMilliseconds = 1000;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
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

            if (attempt < maxAttempts)
            {
                Thread.Sleep(delayMilliseconds);
                delayMilliseconds *= 2;
            }
        }

        throw lastException;
    }
}