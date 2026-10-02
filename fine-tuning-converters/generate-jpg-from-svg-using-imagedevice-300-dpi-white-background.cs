// Generate a JPG from SVG using ImageDevice with 300 DPI resolution and white background color.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path and output JPG path
            System.String svgPath = "sample.svg";
            System.String outputPath = "output.jpg";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                System.String svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Configure image save options for JPEG with 300 DPI and white background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}