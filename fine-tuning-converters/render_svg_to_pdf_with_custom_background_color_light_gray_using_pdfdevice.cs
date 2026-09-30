// Render an SVG to PDF with a custom background color of light gray using PdfDevice.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string svgPath = "sample.svg";
                string pdfPath = "output.pdf";

                if (!System.IO.File.Exists(svgPath))
                {
                    System.IO.File.WriteAllText(svgPath,
                        "<svg xmlns='http://www.w3.org/2000/svg' width='600' height='500'><rect width='600' height='500' fill='red'/></svg>");
                }

                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);
                Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();

                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.BackgroundColor = System.Drawing.Color.LightGray;
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 500));

                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
                renderer.Render(device, document);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}