// Implement a retry mechanism that reattempts EPUB to GIF conversion up to three times on failure.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Ensure the input file exists (create an empty placeholder if missing)
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            int maxAttempts = 3;
            int attempt = 0;
            bool success = false;

            while (attempt < maxAttempts && !success)
            {
                attempt++;
                try
                {
                    using (System.IO.FileStream epubStream = System.IO.File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
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
                        Console.WriteLine("All attempts failed.");
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