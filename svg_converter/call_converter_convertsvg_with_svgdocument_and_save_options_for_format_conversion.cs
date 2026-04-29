// Call Converter.ConvertSVG with SVGDocument and save options to perform format conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace SvgConversionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output paths
                string dataDir = "Data";
                string outputDir = "Output";
                string sourceSvgPath = Path.Combine(dataDir, "sample.svg");
                string outputPath = Path.Combine(outputDir, "sample.jpg");

                // Load the SVG document
                SVGDocument svgDoc = new SVGDocument(sourceSvgPath);

                // Configure image save options (JPEG format)
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Perform the conversion
                Converter.ConvertSVG(svgDoc, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}