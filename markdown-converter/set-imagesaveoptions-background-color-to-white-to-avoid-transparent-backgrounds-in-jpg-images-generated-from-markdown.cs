// Set ImageSaveOptions.BackgroundColor to white to avoid transparent backgrounds in JPG images generated from Markdown.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample markdown content
            string markdown = "# Hello World\nThis is a sample markdown converted to JPG.";
            // Convert markdown to HTML document
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Define output path
            string outputPath = "output.jpg";

            // Convert HTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Image saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}