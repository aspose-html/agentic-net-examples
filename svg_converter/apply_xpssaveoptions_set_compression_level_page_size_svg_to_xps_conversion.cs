// Apply XpsSaveOptions to set compression level and page size during SVG to XPS conversion.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace SvgToXpsExample
{
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
                    options.BackgroundColor = System.Drawing.Color.AliceBlue;

                    Page page = new Page(
                        new Size(600, 800),
                        new Margin(0, 0, 0, 0));

                    options.PageSetup.AnyPage = page;

                    Converter.ConvertSVG(document, options, outputPath);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}