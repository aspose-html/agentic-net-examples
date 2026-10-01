// Convert an SVG to GIF and set background color to white using ImageSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string svgPath = "sample.svg";
            File.WriteAllText(svgPath, svgContent);

            // Load SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            // Output path
            string outputPath = "output.gif";

            // Convert SVG to image
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to GIF: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}