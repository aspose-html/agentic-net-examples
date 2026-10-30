// Batch convert all Markdown files in a folder to JPEG images applying a uniform quality level.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputMarkdown");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            string sampleMarkdown = Path.Combine(inputFolder, "sample.md");
            if (!File.Exists(sampleMarkdown))
            {
                File.WriteAllText(sampleMarkdown, "# Sample Markdown\r\n\r\nThis is a test markdown file.");
            }

            // Process each markdown file
            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                // Convert markdown to HTMLDocument
                using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath))
                {
                    // Configure image save options for JPEG
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Determine output image path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".jpeg");

                    // Convert HTML to JPEG image
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}