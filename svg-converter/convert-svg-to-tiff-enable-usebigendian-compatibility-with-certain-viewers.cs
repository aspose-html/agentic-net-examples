// Convert an SVG to TIFF and enable ImageSaveOptions.UseBigEndian for compatibility with certain viewers.

using System;
using System.IO;
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
            // Input and output paths
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green' /></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Configure image save options for TIFF
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Note: UseBigEndian property is not available in the current API version.

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG has been successfully converted to TIFF: {tiffPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}