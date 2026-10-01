// Convert an SVG file to XPS using the one‑line Converter.ConvertSVG static method.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string dataDir = Directory.GetCurrentDirectory();
            string svgPath = Path.Combine(dataDir, "sample.svg");
            File.WriteAllText(svgPath, svgContent);

            // Prepare output directory
            string outputDir = Path.Combine(dataDir, "Output");
            Directory.CreateDirectory(outputDir);

            // 1. Convert SVG file to XPS with custom options
            string xpsPath1 = Path.Combine(outputDir, "output_file.xps");
            var xpsOptions1 = new Aspose.Html.Saving.XpsSaveOptions();
            xpsOptions1.HorizontalResolution = 300;
            xpsOptions1.VerticalResolution = 300;
            xpsOptions1.BackgroundColor = System.Drawing.Color.AliceBlue;
            var page1 = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            xpsOptions1.PageSetup.AnyPage = page1;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, xpsOptions1, xpsPath1);

            // 2. Convert SVG document (loaded from file) to XPS with same options
            string xpsPath2 = Path.Combine(outputDir, "output_doc.xps");
            using (var svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var xpsOptions2 = new Aspose.Html.Saving.XpsSaveOptions();
                xpsOptions2.HorizontalResolution = 300;
                xpsOptions2.VerticalResolution = 300;
                xpsOptions2.BackgroundColor = System.Drawing.Color.AliceBlue;
                var page2 = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
                xpsOptions2.PageSetup.AnyPage = page2;
                Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, xpsOptions2, xpsPath2);
            }

            // 3. Convert SVG file to PDF
            string pdfPath = Path.Combine(outputDir, "output.pdf");
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);

            // 4. Convert SVG file to DOC
            string docPath = Path.Combine(outputDir, "output.doc");
            var docOptions = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, docOptions, docPath);

            // 5. Convert SVG file to GIF image
            string gifPath = Path.Combine(outputDir, "output.gif");
            var gifOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, gifOptions, gifPath);

            // 6. Convert SVG file to JPEG image
            string jpegPath = Path.Combine(outputDir, "output.jpg");
            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, jpegOptions, jpegPath);

            // 7. Load SVG document, modify, and save as SVG with options
            string modifiedSvgPath = Path.Combine(outputDir, "modified.svg");
            using (var svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var svgSaveOptions = new Aspose.Html.Dom.Svg.Saving.SVGSaveOptions();
                svgDoc.Save(modifiedSvgPath, svgSaveOptions);
            }

            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}