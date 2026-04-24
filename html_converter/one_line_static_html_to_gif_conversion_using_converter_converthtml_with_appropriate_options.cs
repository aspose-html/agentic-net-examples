// Perform a one‑line static conversion of HTML string to GIF by invoking Converter.ConvertHTML with appropriate options.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string html = "<html><body><h1>Hello, GIF!</h1></body></html>";
            // Destination GIF file path
            string outputPath = "output.gif";

            // Load the HTML string into an HTMLDocument
            HTMLDocument document = new HTMLDocument(html);

            // Configure image saving options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Perform the conversion from HTML to GIF
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}