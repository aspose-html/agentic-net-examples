// Convert HTML string containing embedded base64 images to JPEG while preserving image quality.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content with an embedded base64 image
            string htmlContent = "<html><body><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=\" /></body></html>";

            // Create an HTMLDocument from the inline HTML string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for JPEG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Define output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.jpg");

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Conversion completed. JPEG saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}