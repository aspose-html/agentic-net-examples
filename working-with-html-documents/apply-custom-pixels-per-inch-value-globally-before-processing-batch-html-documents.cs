// Apply a custom PixelsPerInch value globally before processing a batch of HTML documents.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input_html");
            Directory.CreateDirectory(inputDir);
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output_images");
            Directory.CreateDirectory(outputDir);

            // Create sample HTML files
            string[] inputs = new string[]
            {
                Path.Combine(inputDir, "sample1.html"),
                Path.Combine(inputDir, "sample2.html")
            };

            File.WriteAllText(inputs[0], "<!DOCTYPE html><html><body><h1>Sample 1</h1></body></html>");
            File.WriteAllText(inputs[1], "<!DOCTYPE html><html><body><h1>Sample 2</h1></body></html>");

            // Define custom DPI (PixelsPerInch) to apply globally
            int customDpi = 300;

            for (int i = 0; i < inputs.Length; i++)
            {
                using (HTMLDocument document = new HTMLDocument(inputs[i]))
                {
                    // Configure image save options with custom DPI
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.HorizontalResolution = customDpi;
                    options.VerticalResolution = customDpi;

                    string outputPath = Path.Combine(outputDir, $"output_{i + 1}.jpg");

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