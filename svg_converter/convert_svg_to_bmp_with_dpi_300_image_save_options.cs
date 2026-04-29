// Convert an SVG to BMP while specifying a DPI of 300 in ImageSaveOptions.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string sourcePath = "input.svg";

            // Path where the BMP image will be saved
            string savePath = "output.bmp";

            // Load the SVG document from the file system
            SVGDocument document = new SVGDocument(sourcePath);

            // Create image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Set the desired DPI (horizontal and vertical resolution)
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Perform the conversion
            Converter.ConvertSVG(document, options, savePath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}