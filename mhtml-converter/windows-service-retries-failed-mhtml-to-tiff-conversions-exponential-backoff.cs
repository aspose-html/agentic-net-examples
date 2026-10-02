// Develop a Windows service that retries failed MHTML to TIFF conversions using an exponential backoff strategy.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.tiff";
            int maxAttempts = 5;

            // Create a minimal sample MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body>Sample MHTML content</body></html>");
            }

            ConvertMhtmlToTiffWithRetry(inputPath, outputPath, maxAttempts);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlToTiffWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        System.Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                // Success, exit the method
                return;
            }
            catch (System.IO.IOException ex)
            {
                lastException = ex;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                lastException = ex;
            }

            if (attempt < maxAttempts)
            {
                int delayMilliseconds = (int)System.Math.Pow(2, attempt - 1) * 1000;
                System.Threading.Thread.Sleep(delayMilliseconds);
            }
        }

        // All attempts failed, rethrow the last exception
        throw lastException;
    }
}