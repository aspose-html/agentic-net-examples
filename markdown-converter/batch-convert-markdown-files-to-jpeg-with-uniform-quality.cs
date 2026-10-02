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
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputMarkdown");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.md");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a **test** markdown file.");
            }

            foreach (string markdownPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                // Convert Markdown to HTMLDocument
                using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath))
                {
                    // Configure image save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Determine output image path
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(markdownPath) + ".jpeg");

                    // Convert HTMLDocument to JPEG image
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