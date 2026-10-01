// Load SVG markup from a string and convert it to PDF with high precision using PdfDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svgCode = "<svg width=\"200\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\"><circle cx=\"100\" cy=\"100\" r=\"80\" fill=\"green\" /></svg>";
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgCode);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

            string savePath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();
            renderer.Render(device, document);

            device.Dispose();

            Console.WriteLine("SVG converted to PDF successfully: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}