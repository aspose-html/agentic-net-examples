// Batch convert HTML files to JPG, logging each file's resolution and background color settings for audit.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Prepare input directory and sample files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputDir);

            string[] inputs = new string[]
            {
                Path.Combine(inputDir, "sample1.html"),
                Path.Combine(inputDir, "sample2.html")
            };

            // Create minimal sample HTML files if they do not exist
            string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            foreach (string path in inputs)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, sampleContent);
                }
            }

            // Process each HTML file
            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    // Configure image save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = Color.Beige;

                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                    // Convert HTML to JPEG
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                    // Log conversion details
                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                    Console.WriteLine($"Resolution: {options.HorizontalResolution}x{options.VerticalResolution} DPI, BackgroundColor: {options.BackgroundColor.Name}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}