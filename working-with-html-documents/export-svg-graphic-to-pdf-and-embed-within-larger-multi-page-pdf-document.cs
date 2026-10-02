// Export an SVG graphic to PDF and embed it within a larger multi‑page PDF document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG files
            string blankSvgPath = "blank.svg";
            string svgPath = "sample.svg";
            string outputPdfPath = "output.pdf";

            string blankSvgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='600' height='400'></svg>";
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='600' height='400'>" +
                                "<rect width='600' height='400' fill='lightblue'/>" +
                                "<circle cx='300' cy='200' r='100' fill='orange'/>" +
                                "</svg>";

            File.WriteAllText(blankSvgPath, blankSvgContent);
            File.WriteAllText(svgPath, svgContent);

            // Load SVG documents
            Aspose.Html.Dom.Svg.SVGDocument doc1 = new Aspose.Html.Dom.Svg.SVGDocument(blankSvgPath);
            Aspose.Html.Dom.Svg.SVGDocument doc2 = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Set up PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 400));

            // Create PDF device
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPdfPath);

            // Render both SVG documents into the same PDF (multi‑page)
            Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();
            renderer.Render(device, doc1, doc2);

            // Cleanup
            device.Dispose();

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}