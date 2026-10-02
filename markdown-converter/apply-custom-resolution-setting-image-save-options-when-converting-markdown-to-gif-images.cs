// Apply a custom resolution setting in ImageSaveOptions when converting Markdown to GIF images.

using System;
using System.IO;
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
            string markdownContent = "# Hello World\nThis is a sample markdown.";
            File.WriteAllText(sourcePath, markdownContent);

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            string outputPath = "output.gif";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}