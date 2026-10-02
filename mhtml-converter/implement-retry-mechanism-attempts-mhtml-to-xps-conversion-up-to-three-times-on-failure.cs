// Implement a retry mechanism that attempts MHTML to XPS conversion up to three times on failure.

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
            string outputPath = "output.xps";

            // Create a minimal MHTML (HTML) file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            ConvertMhtmlToXpsWithRetry(inputPath, outputPath, 3);
            Console.WriteLine("MHTML to XPS conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToXpsWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Conversion succeeded on attempt {attempt}.");
                    return;
                }
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
                Thread.Sleep(1000); // Wait 1 second before retrying
            }
        }

        // All attempts failed; rethrow the last captured exception
        throw lastException ?? new Exception("Conversion failed without a captured exception.");
    }
}