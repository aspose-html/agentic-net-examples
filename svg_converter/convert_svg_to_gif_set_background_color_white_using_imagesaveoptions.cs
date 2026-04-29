// Convert an SVG to GIF and set background color to white using ImageSaveOptions.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string sourcePath = "input.svg";
            // Path where the GIF will be saved
            string outputPath = "output.gif";

            // Load the SVG document
            SVGDocument document = new SVGDocument(sourcePath);

            // Create image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // Set background color to white
            options.BackgroundColor = Color.White;

            // Convert SVG to GIF using the configured options
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}