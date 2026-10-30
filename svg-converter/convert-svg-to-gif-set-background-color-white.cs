// Convert an SVG to GIF and set background color to white using ImageSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output GIF paths
            string documentPath = "sample.svg";
            string savePath = "output.gif";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(documentPath))
            {
                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
                File.WriteAllText(documentPath, svgContent);
            }

            // Load the SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(documentPath);

            // Configure image save options for GIF with white background
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to GIF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);

            Console.WriteLine("SVG has been successfully converted to GIF with a white background.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}