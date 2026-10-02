// Set XpsSaveOptions to use a custom page margin configuration for SVG documents with irregular dimensions.

using System;
using System.IO;
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
            // Prepare sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='100'><rect width='200' height='100' fill='red'/></svg>";
            string documentPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            File.WriteAllText(documentPath, svgContent);

            // Load SVG document
            SVGDocument document = new SVGDocument(documentPath);

            // Configure XPS save options with custom page size and margins
            XpsSaveOptions options = new XpsSaveOptions();

            // Irregular page size (e.g., 300x150 points) and custom margins (left, top, right, bottom)
            Size pageSize = new Size(300, 150);
            Margin pageMargin = new Margin(10, 20, 10, 20);
            Page page = new Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Optional: set resolution and background color
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;

            // Output XPS file path
            string outputPath = Path.Combine(Path.GetTempPath(), "output.xps");

            // Convert SVG to XPS
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}