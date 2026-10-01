// Embed fonts in PdfSaveOptions during SVG to PDF conversion for consistent text appearance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = "<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='80' fill='green' /></svg>";

            // Paths for temporary SVG and final PDF outputs
            string tempSvgPath = "temp.svg";
            string pdfOutputPath = "output.pdf";
            string renderedPdfPath = "rendered.pdf";

            // Write SVG content to a temporary file
            File.WriteAllText(tempSvgPath, svgCode);

            // -----------------------------------------------------------------
            // 1. Convert SVG file to PDF using Converter API
            // -----------------------------------------------------------------
            var pdfSaveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(tempSvgPath, pdfSaveOptions, pdfOutputPath);
            Console.WriteLine($"SVG converted to PDF using Converter API: {pdfOutputPath}");

            // -----------------------------------------------------------------
            // 2. Render SVG to PDF using Rendering API (with background color and page size)
            // -----------------------------------------------------------------
            var svgDocument = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);

            var svgRenderer = new Aspose.Html.Rendering.SvgRenderer();

            var renderingOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions
            {
                BackgroundColor = System.Drawing.Color.LightGray
            };
            renderingOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(600, 800));

            var pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(renderingOptions, renderedPdfPath);

            svgRenderer.Render(pdfDevice, svgDocument);
            Console.WriteLine($"SVG rendered to PDF using Rendering API: {renderedPdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}