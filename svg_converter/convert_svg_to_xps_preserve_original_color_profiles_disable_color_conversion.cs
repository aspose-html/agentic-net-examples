// Convert SVG to XPS while preserving original color profiles by disabling color conversion in options.

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
            string sourcePath = "input.svg";
            string outputPath = "output.xps";

            using (SVGDocument document = new SVGDocument(sourcePath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.Transparent;

                Page page = new Page(new Size(800, 600), new Margin(0, 0, 0, 0));
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