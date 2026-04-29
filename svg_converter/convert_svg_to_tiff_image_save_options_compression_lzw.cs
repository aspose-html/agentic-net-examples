// Convert an SVG file to TIFF using ImageSaveOptions and set Compression to LZW.

using System;
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
            // Path where the TIFF image will be saved
            string outputPath = "output.tiff";

            // Load the SVG document from the file system
            SVGDocument document = new SVGDocument(sourcePath);

            // Create image save options for TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            // Set compression to LZW
            options.Compression = Compression.LZW;
            // Optional: set resolution (dpi)
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            // Perform the conversion
            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}