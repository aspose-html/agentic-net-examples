// Create a Windows service that converts incoming Markdown emails to PNG attachments in real time.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content representing an email body
            string markdown = "# Sample Email\nThis is a **markdown** email converted to PNG.";

            // Convert markdown to HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Set image save options for PNG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Define output PNG file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EmailImage.png");

            // Convert HTML document to PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PNG image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}