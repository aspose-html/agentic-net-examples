// Implement a retry policy that waits two seconds between attempts for SVG to GIF conversion failures.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            string svgFileName = "sample.svg";
            string gifFileName = "sample.gif";
            string svgPath = Path.Combine(inputFolder, svgFileName);
            string gifPath = Path.Combine(outputFolder, gifFileName);

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            const int maxAttempts = 3;
            bool success = false;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    // Load SVG as HTMLDocument
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(svgPath);

                    // Set up image save options for GIF format
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, gifPath);

                    Console.WriteLine($"Conversion succeeded on attempt {attempt}.");
                    success = true;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                    if (attempt == maxAttempts)
                    {
                        throw;
                    }
                    // Wait 2 seconds before next attempt
                    Thread.Sleep(2000);
                }
            }

            if (!success)
            {
                Console.WriteLine("Conversion failed after all attempts.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}