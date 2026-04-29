// Set ImageSaveOptions background color to white when converting SVG to JPEG.

using System;
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
            // Path to the source SVG file
            string sourcePath = "input.svg";

            // Path for the output JPEG file
            string outputPath = "output.jpg";

            // Load the SVG document
            SVGDocument document = new SVGDocument(sourcePath);

            // Create image save options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Set the background color to white
            options.BackgroundColor = Color.White;

            // Convert SVG to JPEG with the specified options
            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}