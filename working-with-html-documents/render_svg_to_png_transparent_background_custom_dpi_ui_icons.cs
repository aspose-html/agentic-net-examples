// Render an SVG file to PNG with transparent background and custom DPI for UI icons.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output image paths
            string inputSvgPath = "sample.svg";
            string outputImagePath = "output.png";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputSvgPath))
            {
                string svgContent = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""200"" height=""200""><rect width=""200"" height=""200"" fill=""red""/></svg>";
                File.WriteAllText(inputSvgPath, svgContent);
            }

            // Load the SVG document
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                // Configure image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = Color.White;
                options.UseAntialiasing = true;

                // Convert SVG to PNG image
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputImagePath);
            }

            Console.WriteLine($"SVG has been successfully converted to image: {Path.GetFileName(outputImagePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}