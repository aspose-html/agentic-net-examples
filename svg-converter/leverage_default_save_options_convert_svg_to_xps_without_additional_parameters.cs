// Leverage the default save options to quickly convert SVG to XPS without specifying additional parameters.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputSvgPath = "sample.svg";
            string outputXpsPath = "output.xps";
            string outputPdfPath = "output.pdf";
            string outputJpegPath = "output.jpg";
            string outputDocPath = "output.docx";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputSvgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
                File.WriteAllText(inputSvgPath, svgContent);
            }

            // Convert SVG to XPS with custom options
            using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                Aspose.Html.Saving.XpsSaveOptions xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
                xpsOptions.HorizontalResolution = 300;
                xpsOptions.VerticalResolution = 300;
                xpsOptions.BackgroundColor = System.Drawing.Color.AliceBlue;

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(800, 600);
                Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
                xpsOptions.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, xpsOptions, outputXpsPath);
            }

            // Convert SVG to PDF
            using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, pdfOptions, outputPdfPath);
            }

            // Convert SVG to JPEG image
            using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, imgOptions, outputJpegPath);
            }

            // Convert SVG to DOCX
            using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                Aspose.Html.Saving.DocSaveOptions docOptions = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, docOptions, outputDocPath);
            }

            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}