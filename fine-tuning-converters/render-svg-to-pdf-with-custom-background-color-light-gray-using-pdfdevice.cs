// Render an SVG to PDF with a custom background color of light gray using PdfDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "sample.svg";
            string pdfPath = "output.pdf";

            // Create a minimal SVG file if it does not exist
            if (!System.IO.File.Exists(svgPath))
            {
                System.IO.File.WriteAllText(svgPath,
                    "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>");
            }

            // Load SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Create renderer
            Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();

            // Set rendering options with light gray background
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.LightGray;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 500));

            // Create PDF device
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);

            // Render SVG to PDF
            renderer.Render(device, document);

            Console.WriteLine("SVG has been rendered to PDF successfully: " + pdfPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}