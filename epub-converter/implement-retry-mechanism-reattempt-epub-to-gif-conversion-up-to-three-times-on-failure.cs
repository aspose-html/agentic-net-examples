// Implement a retry mechanism that reattempts EPUB to GIF conversion up to three times on failure.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        const string inputPath = "sample.epub";
        const string outputPath = "output.gif";

        // Ensure the input file exists to avoid FileNotFoundException.
        if (!File.Exists(inputPath))
        {
            File.WriteAllBytes(inputPath, new byte[0]);
        }

        const int maxAttempts = 3;
        int attempt = 0;
        bool success = false;

        try
        {
            while (attempt < maxAttempts && !success)
            {
                attempt++;
                try
                {
                    using (FileStream epubStream = File.OpenRead(inputPath))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                    }

                    Console.WriteLine($"Conversion succeeded on attempt {attempt}.");
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                    if (attempt >= maxAttempts)
                    {
                        Console.WriteLine("All attempts failed. Conversion could not be completed.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}