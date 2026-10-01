// Create a PowerShell script that iterates over Markdown files and converts each to a TIFF image.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure directories exist
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample markdown file if none exist
            string[] existingFiles = Directory.GetFiles(inputDir, "*.md");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\r\nThis is a *test* markdown file.");
            }

            // Process each markdown file
            foreach (string sourcePath in Directory.GetFiles(inputDir, "*.md"))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                // Convert markdown to HTML document
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                // Set image save options for TIFF format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

                // Convert HTML document to TIFF image
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}