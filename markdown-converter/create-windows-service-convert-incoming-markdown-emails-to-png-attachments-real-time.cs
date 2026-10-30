// Create a Windows service that converts incoming Markdown emails to PNG attachments in real time.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string markdownPath = Path.Combine(dataDir, "sample.md");
            string outputPath = Path.Combine(dataDir, "output.png");

            // Sample markdown content
            string markdownContent = "# Hello World\nThis is a **markdown** sample.";

            // Write markdown to file
            File.WriteAllText(markdownPath, markdownContent);

            // Convert markdown file to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

            // Set PNG image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Convert HTMLDocument to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Markdown converted to PNG: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}