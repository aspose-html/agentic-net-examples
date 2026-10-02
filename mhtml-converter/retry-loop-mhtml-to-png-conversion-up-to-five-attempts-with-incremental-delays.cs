// Implement a retry loop that attempts MHTML to PNG conversion up to five times with incremental delays.

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
            string outputPath = "output.png";

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            ConvertMhtmlToPngWithRetry(inputPath, outputPath, 5);
            Console.WriteLine("Conversion succeeded. Output saved to: " + outputPath);
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
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                // Success, exit the retry loop
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

            if (attempt == maxAttempts)
            {
                break;
            }

            // Incremental delay: attempt seconds * 1000 ms
            Thread.Sleep(attempt * 1000);
        }

        // After all attempts failed, rethrow the last captured exception
        throw lastException ?? new Exception("Conversion failed after multiple attempts.");
    }
}