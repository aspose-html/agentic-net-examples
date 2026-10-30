// Set ImageSaveOptions.BackgroundColor to white to avoid transparent backgrounds in JPG images generated from Markdown.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Title\n\nThis is a **markdown** sample.";

            // Convert markdown to HTMLDocument
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Set up image save options for JPEG with white background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.BackgroundColor = System.Drawing.Color.White;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            // Convert HTML to JPEG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}