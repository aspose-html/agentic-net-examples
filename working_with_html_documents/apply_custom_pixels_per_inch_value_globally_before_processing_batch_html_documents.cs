// Apply a custom PixelsPerInch value globally before processing a batch of HTML documents.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Input HTML files
            string[] inputs = new string[] { "input1.html", "input2.html" };

            // Desired DPI (pixels per inch)
            int dpi = 300;

            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                // Load HTML document
                using (var document = new HTMLDocument(inputPath, Directory.GetCurrentDirectory()))
                {
                    // Configure image conversion options with custom resolution
                    var options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.HorizontalResolution = dpi;
                    options.VerticalResolution = dpi;

                    // Define output image path
                    string outputPath = Path.Combine(outputDir, $"output_{i}.jpeg");

                    // Convert HTML to JPEG
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}