// Convert an SVG to TIFF with no compression by setting ImageSaveOptions.Compression to None.

using System;
using System.IO;

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
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='lightblue'/>
    <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options for TIFF
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG has been successfully converted to TIFF at: {Path.GetFullPath(tiffPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}