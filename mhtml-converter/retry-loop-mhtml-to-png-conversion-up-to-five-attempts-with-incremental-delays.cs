// Implement a retry loop that attempts MHTML to PNG conversion up to five times with incremental delays.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            // Ensure a minimal MHTML file exists
            if (!File.Exists(inputPath))
            {
                string minimalContent = "<html><body><h1>Sample</h1></body></html>";
                File.WriteAllText(inputPath, minimalContent);
            }

            ConvertMhtmlToPngWithRetry(inputPath, outputPath, 5);
            Console.WriteLine("Conversion succeeded: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlToPngWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
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
            catch (Exception ex)
            {
                lastException = ex;
            }

            // Incremental delay before next attempt
            int delayMilliseconds = attempt * 1000; // 1s, 2s, 3s, ...
            Thread.Sleep(delayMilliseconds);
        }

        // All attempts failed
        throw lastException ?? new Exception("Conversion failed after multiple attempts.");
    }
}