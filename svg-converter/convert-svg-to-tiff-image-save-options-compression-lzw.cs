// Convert an SVG file to TIFF using ImageSaveOptions and set Compression to LZW.

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
            // Define input and output paths
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

            // Configure image save options for TIFF with LZW compression
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.LZW;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine("SVG has been successfully converted to TIFF: " + Path.GetFullPath(tiffPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}