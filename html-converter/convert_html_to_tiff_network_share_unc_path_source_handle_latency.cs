// Convert HTML to TIFF using a network share UNC path as source and handle potential latency.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // UNC paths for input HTML and output TIFF
            string inputPath = @"\\server\share\input.html";
            string outputPath = @"\\server\share\output.tiff";

            // Attempt to load the HTML document with simple retry logic to handle possible latency
            const int maxAttempts = 3;
            int attempt = 0;
            Aspose.Html.HTMLDocument document = null;

            while (attempt < maxAttempts)
            {
                try
                {
                    document = new Aspose.Html.HTMLDocument(inputPath);
                    break; // Success
                }
                catch (IOException)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                        throw;
                    // Wait before retrying
                    Thread.Sleep(1000);
                }
            }

            // Configure image save options for TIFF format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Tiff);

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}