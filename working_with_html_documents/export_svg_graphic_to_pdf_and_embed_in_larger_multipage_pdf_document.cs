// Export an SVG graphic to PDF and embed it within a larger multi‑page PDF document.

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
            // Path to the source SVG file
            string svgPath = "input.svg";
            // Path to the intermediate PDF generated from the SVG
            string svgPdfPath = "svg_page.pdf";

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Create a renderer for SVG content
            SvgRenderer renderer = new SvgRenderer();

            // Configure PDF rendering options with a custom page size (600x500)
            PdfRenderingOptions options = new PdfRenderingOptions();
            Page page = new Page(new Size(600, 500));
            options.PageSetup.AnyPage = page;

            // Create a PDF device that writes the rendered content to a file
            PdfDevice device = new PdfDevice(options, svgPdfPath);

            // Render the SVG document to the PDF device
            renderer.Render(device, document);

            // NOTE: Embedding the generated PDF into a larger multi‑page PDF document
            // would require additional PDF manipulation APIs (e.g., Aspose.PDF), which
            // are not covered by the provided rules. This step is therefore omitted.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}