// Write a wrapper function that abstracts Converter.ConvertSVG calls for different target formats.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Output paths
            string jpegPath = "output.jpg";
            string tiffPath = "output.tiff";
            string pdfPath = "output.pdf";

            // Convert SVG string to JPEG
            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, jpegOptions, jpegPath);
            Console.WriteLine($"SVG converted to JPEG: {jpegPath}");

            // Convert SVG string to TIFF with specific options
            var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, tiffOptions, tiffPath);
            Console.WriteLine($"SVG converted to TIFF: {tiffPath}");

            // Convert SVG string to PDF
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, pdfOptions, pdfPath);
            Console.WriteLine($"SVG converted to PDF: {pdfPath}");

            // Create temporary SVG file
            string tempSvgPath = "temp.svg";
            File.WriteAllText(tempSvgPath, svgCode);

            // Load SVG document from file
            var svgDocument = new Aspose.Html.Dom.Svg.SVGDocument(tempSvgPath);

            // Convert SVGDocument to TIFF using document overload
            string tiffFromDocPath = "output_from_doc.tiff";
            var tiffDocOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffDocOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffDocOptions.HorizontalResolution = 200;
            tiffDocOptions.VerticalResolution = 200;
            Aspose.Html.Converters.Converter.ConvertSVG(svgDocument, tiffDocOptions, tiffFromDocPath);
            Console.WriteLine($"SVGDocument converted to TIFF: {tiffFromDocPath}");

            // Clean up temporary file
            if (File.Exists(tempSvgPath))
                File.Delete(tempSvgPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}