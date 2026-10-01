// Develop a Windows service that retries failed MHTML to TIFF conversions using an exponential backoff strategy.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            ConvertMhtmlToTiffWithRetry(inputPath, outputPath, 5);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToTiffWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        int delay = 1000; // initial delay in milliseconds

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                return; // success
            }
            catch (System.IO.IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (System.UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            if (attempt < maxAttempts)
            {
                Thread.Sleep(delay);
                delay *= 2; // exponential backoff
            }
        }

        throw lastException ?? new Exception("Conversion failed after retries.");
    }
}