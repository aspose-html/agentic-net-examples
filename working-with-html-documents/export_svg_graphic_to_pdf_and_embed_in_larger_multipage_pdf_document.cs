// Export an SVG graphic to PDF and embed it within a larger multi‑page PDF document.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
                                      <rect width='200' height='200' fill='lightblue'/>
                                   </svg>";

            // Create temporary SVG file
            string tempSvgPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            File.WriteAllText(tempSvgPath, svgContent);

            // Load SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);

            // Create SVG renderer
            Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();

            // Set PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 800));

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create PDF device
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            // Render SVG to PDF
            renderer.Render(device, document);

            Console.WriteLine($"SVG has been successfully converted to PDF at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}