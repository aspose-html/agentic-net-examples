// Log each SVG to DOCX conversion, including page count and any custom DocSaveOptions applied.

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
            // Define SVG source files
            string[] svgFiles = { "input1.svg", "input2.svg" };

            foreach (var svgPath in svgFiles)
            {
                // Prepare output DOCX path
                string outputPath = Path.ChangeExtension(svgPath, ".docx");

                // Load SVG document
                SVGDocument document = new SVGDocument(svgPath);

                // Create DocSaveOptions and configure page layout
                DocSaveOptions options = new DocSaveOptions();
                Size size = new Size(500, 500); // width, height
                Margin margin = new Margin(30, 10, 10, 10); // top, right, bottom, left
                Page page = new Page(size, margin);
                options.PageSetup.AnyPage = page;

                // Perform conversion
                Converter.ConvertSVG(document, options, outputPath);

                // Log conversion details
                Console.WriteLine($"Converted '{svgPath}' to '{outputPath}'.");
                Console.WriteLine($"Page size: {size.Width}x{size.Height}, Margins - Top:{margin.Top}, Right:{margin.Right}, Bottom:{margin.Bottom}, Left:{margin.Left}.");
                Console.WriteLine("Page count: N/A (not available via Aspose.HTML API).");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}