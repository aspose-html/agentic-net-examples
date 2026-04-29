// Load an SVG from a local path and convert it to XPS with custom page dimensions.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string sourcePath = "input.svg";
            // Desired output XPS file path
            string outputPath = "output.xps";

            // Load the SVG document
            using (SVGDocument document = new SVGDocument(sourcePath))
            {
                // Create XPS save options and configure rendering settings
                XpsSaveOptions options = new XpsSaveOptions();
                options.HorizontalResolution = 200; // DPI
                options.VerticalResolution = 200;   // DPI
                options.BackgroundColor = System.Drawing.Color.AliceBlue; // Background color

                // Define custom page size (500x500) and margins (30,10,10,10)
                Page page = new Page(new Size(500, 500), new Margin(30, 10, 10, 10));
                options.PageSetup.AnyPage = page;

                // Convert SVG to XPS with the specified options
                Converter.ConvertSVG(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}