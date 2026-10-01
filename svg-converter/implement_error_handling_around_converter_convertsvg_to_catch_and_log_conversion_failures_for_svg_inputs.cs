// Implement error handling around Converter.ConvertSVG to catch and log conversion failures for SVG inputs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='2'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>SVG</text>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // High quality JPEG (quality setting omitted due to API constraints)
            string highOutputPath = "high.jpg";
            var highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low quality JPEG (quality setting omitted)
            string lowOutputPath = "low.jpg";
            var lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("High quality JPEG is larger than low quality JPEG.");
            }
            else
            {
                Console.WriteLine("Low quality JPEG is larger than high quality JPEG.");
            }

            // Convert SVG to GIF
            string gifOutputPath = "output.gif";
            var gifOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, gifOptions, gifOutputPath);

            // Convert SVG to PDF using DOM document
            string pdfOutputPath = "output.pdf";
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(document, pdfOptions, pdfOutputPath);
            }

            // Convert SVG to XPS
            string xpsOutputPath = "output.xps";
            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, xpsOptions, xpsOutputPath);

            // Convert SVG to TIFF with specific settings
            string tiffOutputPath = "output.tiff";
            var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, tiffOptions, tiffOutputPath);

            // Convert SVG to DOC
            string docOutputPath = "output.doc";
            var docOptions = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, docOptions, docOutputPath);

            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}