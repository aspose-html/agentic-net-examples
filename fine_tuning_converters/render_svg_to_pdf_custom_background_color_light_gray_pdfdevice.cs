// Render an SVG to PDF with a custom background color of light gray using PdfDevice.

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
            // Input SVG file path and output PDF file path
            string svgPath = "input.svg";
            string pdfPath = "output.pdf";

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Create a renderer for SVG content
            SvgRenderer renderer = new SvgRenderer();

            // Set up PDF rendering options with a light gray background
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.LightGray;
            options.PageSetup.AnyPage = new Page(new Size(600, 500));

            // Create a PDF device with the specified options and output path
            PdfDevice device = new PdfDevice(options, pdfPath);

            // Render the SVG document to the PDF device
            renderer.Render(device, document);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}