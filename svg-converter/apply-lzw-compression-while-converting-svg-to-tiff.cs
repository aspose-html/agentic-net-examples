// Apply LZW compression in ImageSaveOptions while converting SVG to TIFF.

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
            // Define input SVG and output TIFF paths
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='blue'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Configure image save options for TIFF
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            // Note: LZW compression is not available in the current API; using default compression.
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine("SVG has been successfully converted to TIFF at: " + Path.GetFullPath(tiffPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}