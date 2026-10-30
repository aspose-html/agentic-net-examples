// Convert a template with embedded SVG graphics to HTML and render it to PNG preserving vector quality.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG markup
            string svgMarkup = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Output image file path
            string outputPath = "output.jpg";

            // Configure image save options (JPEG format)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Convert SVG markup to JPEG image
            Aspose.Html.Converters.Converter.ConvertSVG(svgMarkup, "", options, outputPath);

            Console.WriteLine($"SVG has been converted and saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}