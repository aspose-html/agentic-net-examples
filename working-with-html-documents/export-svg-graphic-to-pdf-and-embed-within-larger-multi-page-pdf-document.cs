// Export an SVG graphic to PDF and embed it within a larger multi‑page PDF document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            var pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));

            var pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath);

            var htmlRenderer = new Aspose.Html.Rendering.HtmlRenderer();
            var svgRenderer = new Aspose.Html.Rendering.SvgRenderer();

            // First HTML page
            string html1 = "<html><body><h1>First Page</h1></body></html>";
            var baseUri = new Aspose.Html.Url("about:blank");
            var htmlDoc1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            htmlRenderer.Render(pdfDevice, htmlDoc1);

            // SVG page
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green' /></svg>";
            var svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent);
            svgRenderer.Render(pdfDevice, svgDoc);

            // Last HTML page
            string html2 = "<html><body><h1>Last Page</h1></body></html>";
            var htmlDoc2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            htmlRenderer.Render(pdfDevice, htmlDoc2);

            pdfDevice.Dispose();

            Console.WriteLine("PDF created at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}