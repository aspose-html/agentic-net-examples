// Implement a retry mechanism that attempts MHTML to XPS conversion up to three times on failure.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            EnsureSampleFile(inputPath);
            ConvertMhtmlToXpsWithRetry(inputPath, outputPath, 3);

            Console.WriteLine("MHTML to XPS conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }

    static void EnsureSampleFile(string path)
    {
        if (!File.Exists(path))
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(path, htmlContent);
        }
    }

    static void ConvertMhtmlToXpsWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                return; // Success
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
                Thread.Sleep(1000); // Wait before retrying
            }
        }

        throw lastException;
    }
}