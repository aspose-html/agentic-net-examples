// Set XpsSaveOptions to use a custom page margin configuration for SVG documents with irregular dimensions.

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
            string svgPath = "input.svg";
            string outputPath = "output.xps";

            using (SVGDocument document = new SVGDocument(svgPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();

                // Define custom page size and margins
                Page page = new Page(
                    new Size(800, 600),               // width, height
                    new Margin(50, 20, 30, 20)        // top, right, bottom, left
                );

                options.PageSetup.AnyPage = page;

                Converter.ConvertSVG(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}