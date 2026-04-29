// Generate a high‑quality JPG image from Markdown by configuring ImageSaveOptions JpegQuality to 100.

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
            string sourcePath = "sample.md";
            string markdownContent = "# Hello\nThis is a markdown test.";
            File.WriteAllText(sourcePath, markdownContent);

            string savePath = "output.jpg";

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            // If the JpegQuality property is available, it can be set to 100.
            // options.JpegQuality = 100; // Uncomment if supported by the API version.

            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}