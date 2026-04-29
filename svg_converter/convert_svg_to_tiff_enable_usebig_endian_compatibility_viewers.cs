// Convert an SVG to TIFF and enable ImageSaveOptions.UseBigEndian for compatibility with certain viewers.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string sourcePath = "input.svg";

            // Path where the resulting TIFF file will be saved
            string outputPath = "output.tiff";

            // Create image save options specifying TIFF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // The ImageSaveOptions class in Aspose.HTML does not expose a UseBigEndian property.
            // If such a property existed, it would be set here for compatibility with certain viewers.

            // Perform the conversion from SVG to TIFF
            Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to TIFF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}