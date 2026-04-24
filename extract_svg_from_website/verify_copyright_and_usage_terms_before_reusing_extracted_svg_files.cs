// Verify copyright and usage terms before reusing extracted SVG files.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving.ResourceHandlers;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string inputSvgPath = "input.svg";

            // Directory where the SVG and its external resources will be saved
            string outputFolder = "output";

            // Load the SVG document and save it together with all linked resources
            using (SVGDocument doc = new SVGDocument(inputSvgPath))
            {
                var resourceHandler = new FileSystemResourceHandler(outputFolder);
                doc.Save(resourceHandler);
            }

            Console.WriteLine("SVG and its resources have been saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}