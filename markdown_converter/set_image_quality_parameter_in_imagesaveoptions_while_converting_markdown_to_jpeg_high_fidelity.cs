// Set image quality parameter in ImageSaveOptions while converting Markdown to JPEG with high fidelity.

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
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string sourcePath = Path.Combine(dataDir, "sample.md");
            string outputPath = Path.Combine(dataDir, "output.jpg");

            // Write sample markdown content
            string markdownContent = "# Hello World\nThis is a **markdown** document.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Prepare image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTMLDocument to JPEG image
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}