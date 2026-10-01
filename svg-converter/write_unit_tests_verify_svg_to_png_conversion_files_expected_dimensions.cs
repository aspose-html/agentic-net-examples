// Write unit tests to verify that SVG to PNG conversion produces files of expected dimensions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Output paths for high and low quality images
            string highOutputPath = "high.jpg";
            string lowOutputPath = "low.jpg";

            // High quality options (default JPEG options)
            var highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            // Low quality options (same options, quality cannot be set explicitly)
            var lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Convert SVG to JPEG with both option sets
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Compare file sizes
            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("High quality image is larger than low quality image.");
            }
            else if (lowSize > highSize)
            {
                Console.WriteLine("Low quality image is larger than high quality image.");
            }
            else
            {
                Console.WriteLine("Both images have the same size.");
            }

            // Additional conversion using SVGDocument with resolution and background color
            string docOutputPath = "document.jpg";
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.White;
                options.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, docOutputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}