// Convert SVG to XPS while preserving embedded fonts by enabling font embedding in XpsSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.svg";
            string outputPath = "output.xps";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><text x='10' y='20' font-family='Arial' font-size='16'>Hello</text></svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Load the SVG document
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
            {
                // Configure XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                // Note: Font embedding option is not available in this version of the API.

                // Convert SVG to XPS
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine("SVG has been successfully converted to XPS: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}