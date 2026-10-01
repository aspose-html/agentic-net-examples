// Implement a retry loop that attempts MHTML to PNG conversion up to five times with incremental delays.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            const string inputPath = "sample.mhtml";
            const string outputPath = "output.png";
            const int maxAttempts = 5;

            // Ensure a sample input file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML Content</h1></body></html>");
            }

            Exception lastException = null;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    using (FileStream stream = File.OpenRead(inputPath))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                        // Optional: configure rendering properties if needed
                        // options.UseAntialiasing = true;
                        // options.HorizontalResolution = 96;
                        // options.VerticalResolution = 96;

                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    }

                    Console.WriteLine("Conversion succeeded on attempt {0}.", attempt);
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
                    int delayMilliseconds = attempt * 1000; // incremental delay: 1s, 2s, 3s, ...
                    Console.WriteLine("Attempt {0} failed. Retrying after {1} ms...", attempt, delayMilliseconds);
                    Thread.Sleep(delayMilliseconds);
                }
            }

            // If we reach here, all attempts failed
            throw lastException ?? new Exception("Conversion failed after all retry attempts.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}