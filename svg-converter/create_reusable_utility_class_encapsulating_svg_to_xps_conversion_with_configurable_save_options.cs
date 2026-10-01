// Create a reusable utility class that encapsulates SVG to XPS conversion with configurable save options.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content and file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string inputSvgPath = "sample.svg";
            File.WriteAllText(inputSvgPath, svgContent);
            string outputXps = "output.xps";
            string outputPdf = "output.pdf";
            string outputDoc = "output.docx";
            string outputPng = "output.png";

            // Convert SVG file to XPS with options
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;
                var page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
                options.PageSetup.AnyPage = page;
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputXps);
            }

            // Convert SVG file to PDF
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(document, pdfOptions, outputPdf);
            }

            // Convert SVG file to DOCX
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                var docOptions = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(document, docOptions, outputDoc);
            }

            // Convert SVG file to PNG image
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(inputSvgPath))
            {
                var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
                imgOptions.HorizontalResolution = 300;
                imgOptions.VerticalResolution = 300;
                imgOptions.BackgroundColor = System.Drawing.Color.White;
                imgOptions.UseAntialiasing = true;
                Aspose.Html.Converters.Converter.ConvertSVG(document, imgOptions, outputPng);
            }

            // Direct conversion from SVG string to XPS using base URI
            string directOutputXps = "direct_output.xps";
            var directOptions = new Aspose.Html.Saving.XpsSaveOptions();
            directOptions.HorizontalResolution = 200;
            directOptions.VerticalResolution = 200;
            directOptions.BackgroundColor = System.Drawing.Color.LightGray;
            string baseUri = "file:///";
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, directOptions, directOutputXps);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}