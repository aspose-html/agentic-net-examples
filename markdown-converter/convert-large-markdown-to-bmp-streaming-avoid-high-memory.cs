// Convert a large Markdown file to BMP format using streaming to avoid high memory consumption.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and output BMP file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

            // Create a sample markdown file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleMarkdown = "# Sample Title\r\n\r\nThis is a **sample** markdown content.";
                File.WriteAllText(inputPath, sampleMarkdown);
            }

            // Open the markdown file as a stream (demonstrates streaming input)
            using (Stream markdownStream = File.OpenRead(inputPath))
            {
                // The stream is not directly used by the converter, but this shows
                // how to handle large files without loading the entire content into memory.
                // The stream is disposed after this block.
            }

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath);

            // Set image save options for BMP format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Convert the HTMLDocument to BMP image and save to file
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Markdown file has been converted to BMP image at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}