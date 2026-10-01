// Write a console application that reads SVG file paths from a text file and converts them to XPS.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Load SVG into a document
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgCode))
            {
                // Configure XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Define page layout
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                options.PageSetup.AnyPage = page;

                // Output file path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

                Console.WriteLine($"SVG successfully converted to XPS: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}