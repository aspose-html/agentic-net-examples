// Set ImageSaveOptions background color to white when converting SVG to JPEG.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;

            // Convert SVG to JPEG file
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, options, "output.jpg");

            Console.WriteLine("SVG has been successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}