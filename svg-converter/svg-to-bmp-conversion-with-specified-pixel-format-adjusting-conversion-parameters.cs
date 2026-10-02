// Perform SVG to BMP conversion with a specified pixel format by adjusting the conversion parameters.

using System;
using System.IO;
using System.Drawing;
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
            // Define input SVG path and create a minimal SVG file
            string sourcePath = "sample.svg";
            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Define output BMP path
            string outputPath = "output.bmp";

            // Load SVG document
            SVGDocument document = new SVGDocument(sourcePath);

            // Configure image save options for BMP with custom parameters
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to BMP at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}