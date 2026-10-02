// Render an SVG image to PDF by creating PdfDevice with AnyPage set to 600x500 pixels.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string svgPath = "sample.svg";
            if (!System.IO.File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                System.IO.File.WriteAllText(svgPath, svgContent);
            }

            string pdfPath = "output.pdf";

            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);
            var renderer = new Aspose.Html.Rendering.SvgRenderer();

            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 500));

            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            renderer.Render(device, document);

            Console.WriteLine("SVG rendered to PDF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}