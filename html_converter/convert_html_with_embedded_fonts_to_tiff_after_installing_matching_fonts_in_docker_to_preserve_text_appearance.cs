// Convert HTML with embedded fonts to TIFF after installing matching fonts in Docker to preserve text appearance.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.tiff";

            HTMLDocument document = new HTMLDocument(htmlPath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.None;
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}