// Convert HTML to TIFF using a network share UNC path as source and handle potential latency.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        // UNC paths for source HTML and target TIFF
        string sourcePath = @"\\server\share\input.html";
        string outputPath = @"\\server\share\output.tiff";

        int maxAttempts = 3;
        int attempt = 0;
        bool success = false;

        while (attempt < maxAttempts && !success)
        {
            try
            {
                // Load HTML document from UNC path
                HTMLDocument document = new HTMLDocument(sourcePath);

                // Set image save options to TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                // Convert HTML to TIFF and save to UNC path
                Converter.ConvertHTML(document, options, outputPath);

                success = true;
                Console.WriteLine("Conversion succeeded.");
            }
            catch (Exception ex)
            {
                attempt++;
                Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                if (attempt < maxAttempts)
                {
                    // Wait before retrying to mitigate latency issues
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Conversion failed after multiple attempts.");
                }
            }
        }
    }
}