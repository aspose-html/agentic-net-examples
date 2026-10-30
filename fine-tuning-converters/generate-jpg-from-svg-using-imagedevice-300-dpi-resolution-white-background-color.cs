// Generate a JPG from SVG using ImageDevice with 300 DPI resolution and white background color.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input SVG file path and output JPG file path
            System.String svgPath = "sample.svg";
            System.String outputPath = "output.jpg";

            // Create a minimal SVG file if it does not exist
            if (!System.IO.File.Exists(svgPath))
            {
                System.String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>";
                System.IO.File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options for JPEG with 300 DPI and white background
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            System.Console.WriteLine("SVG has been successfully converted to JPEG: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}