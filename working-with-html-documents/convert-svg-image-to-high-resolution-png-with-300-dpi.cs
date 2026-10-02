// Convert an SVG image to a high‑resolution PNG file with a custom 300 DPI setting.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG file path and output PNG file path
            string documentPath = "sample.svg";
            string savePath = "output.png";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(documentPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(documentPath, svgContent);
            }

            // Load the SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(documentPath);

            // Configure image save options for high resolution PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to PNG with the specified options
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);

            Console.WriteLine("SVG has been successfully converted to high‑resolution PNG at: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}