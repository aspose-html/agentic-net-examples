// Convert Markdown to HTML and then use the HTMLDocument API to render it as a BMP image.

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
            // Prepare a markdown file
            string markdownPath = "sample.md";
            string markdownContent = "# Hello World\r\nThis is a sample markdown.";
            File.WriteAllText(markdownPath, markdownContent);

            // Convert markdown to an HTMLDocument
            Aspose.Html.HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Configure image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Render the HTMLDocument to a BMP image
            string outputPath = "output.bmp";
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}