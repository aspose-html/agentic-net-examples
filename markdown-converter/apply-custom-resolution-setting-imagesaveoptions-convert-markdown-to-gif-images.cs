// Apply a custom resolution setting in ImageSaveOptions when converting Markdown to GIF images.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a sample markdown file
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\nThis is a sample markdown.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set custom resolution in ImageSaveOptions for GIF output
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTMLDocument to GIF image
            string outputPath = "output.gif";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Markdown has been converted to GIF image at '{outputPath}' with custom resolution.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}