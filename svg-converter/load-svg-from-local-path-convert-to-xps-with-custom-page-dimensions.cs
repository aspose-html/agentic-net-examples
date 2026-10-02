// Load an SVG from a local path and convert it to XPS with custom page dimensions.

using System;
using System.Drawing;

namespace SvgToXpsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.svg";
                string outputPath = "sample.xps";

                // Create a minimal SVG file if it does not exist
                if (!System.IO.File.Exists(sourcePath))
                {
                    System.IO.File.WriteAllText(sourcePath,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>");
                }

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.AliceBlue;

                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 600),
                        new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                Console.WriteLine("SVG converted to XPS successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}