// Render an SVG illustration to PDF and apply a color profile conversion during export.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string svgPath = "sample.svg";
            string pdfRenderPath = "rendered.pdf";
            string pdfConvertPath = "converted.pdf";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string sampleSvg = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' />
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='white'>SVG</text>
</svg>";
                File.WriteAllText(svgPath, sampleSvg);
            }

            // Render SVG to PDF using SvgRenderer and PdfDevice
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var renderer = new Aspose.Html.Rendering.SvgRenderer();
                var renderOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                renderOptions.BackgroundColor = System.Drawing.Color.White;
                renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 500));
                var device = new Aspose.Html.Rendering.Pdf.PdfDevice(renderOptions, pdfRenderPath);
                renderer.Render(device, document);
            }

            // Direct conversion using Converter API
            var saveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, saveOptions, pdfConvertPath);

            Console.WriteLine("SVG conversion completed successfully.");
            Console.WriteLine($"Rendered PDF: {pdfRenderPath}");
            Console.WriteLine($"Converted PDF: {pdfConvertPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}