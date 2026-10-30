// Implement a retry mechanism that attempts MHTML to XPS conversion up to three times on failure.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            ConvertMhtmlToXpsWithRetry(inputPath, outputPath, 3);
            System.Console.WriteLine("MHTML to XPS conversion succeeded.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToXpsWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        System.Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                // Conversion succeeded, exit the method
                return;
            }
            catch (System.IO.IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (System.UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            // Wait before the next retry attempt
            System.Threading.Thread.Sleep(1000);
        }

        // All attempts failed, rethrow the last captured exception
        throw lastException;
    }
}