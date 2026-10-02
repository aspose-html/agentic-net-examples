// Load SVG markup from a string and convert it to PDF with high precision using PdfDevice.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green' /></svg>";
                string savePath = "output.pdf";

                Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));

                Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, savePath);

                Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer();

                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgCode);

                renderer.Render(pdfDevice, document);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}