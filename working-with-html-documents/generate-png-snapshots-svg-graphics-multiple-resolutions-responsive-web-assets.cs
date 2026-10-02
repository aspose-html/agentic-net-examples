// Generate PNG snapshots of SVG graphics at multiple resolutions for responsive web assets.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a minimal SVG file
            string svgPath = "sample.svg";
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
            File.WriteAllText(svgPath, svgContent);

            // Define resolutions (DPI) for responsive assets
            int[] resolutions = new int[] { 72, 150, 300 };

            foreach (int dpi in resolutions)
            {
                // Load SVG document
                SVGDocument document = new SVGDocument(svgPath);

                // Configure image save options
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = dpi;
                options.VerticalResolution = dpi;
                options.BackgroundColor = Color.White;
                options.UseAntialiasing = true;

                // Output PNG path
                string outputPath = $"output_{dpi}dpi.png";

                // Convert SVG to PNG
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

                Console.WriteLine($"Saved PNG at {dpi} DPI to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}