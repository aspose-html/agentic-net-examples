// Implement a retry policy that waits two seconds between attempts for SVG to GIF conversion failures.

using System;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        // Paths for source SVG and destination GIF
        string sourcePath = "input.svg";
        string outputPath = "output.gif";

        // Retry configuration
        int maxAttempts = 3;
        int attempt = 0;
        bool success = false;

        while (attempt < maxAttempts && !success)
        {
            try
            {
                attempt++;

                // Create image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Perform the conversion
                Converter.ConvertSVG(sourcePath, options, outputPath);

                success = true;
                Console.WriteLine("Conversion succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");

                // Wait 2 seconds before next attempt if any attempts remain
                if (attempt < maxAttempts)
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("All attempts failed.");
                }
            }
        }
    }
}