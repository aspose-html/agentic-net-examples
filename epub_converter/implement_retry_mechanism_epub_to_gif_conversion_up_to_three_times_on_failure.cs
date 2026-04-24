// Implement a retry mechanism that reattempts EPUB to GIF conversion up to three times on failure.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input EPUB and output GIF
            string inputPath = "input.epub";
            string outputPath = "output.gif";

            const int maxAttempts = 3;
            int attempt = 0;
            bool success = false;

            // Retry loop
            while (attempt < maxAttempts && !success)
            {
                attempt++;
                try
                {
                    // Open the EPUB file as a readable stream
                    using (FileStream stream = File.OpenRead(inputPath))
                    {
                        // Configure image save options for GIF format
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                        // Convert EPUB to GIF
                        Converter.ConvertEPUB(stream, options, outputPath);
                    }

                    // If conversion succeeds, exit loop
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                    if (attempt >= maxAttempts)
                        throw; // Re‑throw after final attempt
                }
            }

            if (success)
                Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Conversion failed: {e.Message}");
        }
    }
}