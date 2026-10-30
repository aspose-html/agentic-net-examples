// Apply a custom PixelsPerInch value globally before processing a batch of HTML documents.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Prepare input files
            string[] inputs = new string[] { "input1.html", "input2.html" };

            // Create minimal sample HTML files if they do not exist
            if (!File.Exists(inputs[0]))
            {
                File.WriteAllText(inputs[0], "<!DOCTYPE html><html><body><h1>Sample 1</h1></body></html>");
            }
            if (!File.Exists(inputs[1]))
            {
                File.WriteAllText(inputs[1], "<!DOCTYPE html><html><body><h1>Sample 2</h1></body></html>");
            }

            // Custom DPI value to apply globally
            int customDpi = 300;

            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    // Configure image save options with custom DPI
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = customDpi;
                    options.VerticalResolution = customDpi;

                    string outputPath = Path.Combine(outputDir, $"output_{i}.jpg");

                    // Convert HTML to image
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}