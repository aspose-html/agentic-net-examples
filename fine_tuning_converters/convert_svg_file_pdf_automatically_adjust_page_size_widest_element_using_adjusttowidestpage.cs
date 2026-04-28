// Convert an SVG file to PDF while automatically adjusting page size to the widest element using AdjustToWidestPage.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input SVG and output PDF files
            string svgPath = "input.svg";
            string pdfPath = "output.pdf";

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Create a renderer for SVG content
            SvgRenderer renderer = new SvgRenderer();

            // Initialize PDF rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Set a placeholder page size and enable automatic adjustment to the widest element
            options.PageSetup.AnyPage = new Page(new Size(600, 500));
            options.PageSetup.AdjustToWidestPage = true;

            // Create a PDF device with the configured options
            PdfDevice device = new PdfDevice(options, pdfPath);

            // Render the SVG document to the PDF device
            renderer.Render(device, document);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}