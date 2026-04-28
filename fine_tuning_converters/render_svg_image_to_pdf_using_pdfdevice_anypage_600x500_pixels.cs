// Render an SVG image to PDF by creating PdfDevice with AnyPage set to 600x500 pixels.

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
            SVGDocument document = new SVGDocument("input.svg");
            SvgRenderer renderer = new SvgRenderer();
            string savePath = "output.pdf";
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 500));
            PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, document);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}