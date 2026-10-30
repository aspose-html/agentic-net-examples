// Write a wrapper function that abstracts Converter.ConvertSVG calls for different target formats.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string svgCode = "<svg width=\"200\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>";
            string jpegOutput = "output.jpeg";
            string pdfOutput = "output.pdf";

            ConvertSvgToImage(svgCode, jpegOutput, ImageFormat.Jpeg);
            Console.WriteLine($"SVG converted to JPEG: {jpegOutput}");

            ConvertSvgToPdf(svgCode, pdfOutput);
            Console.WriteLine($"SVG converted to PDF: {pdfOutput}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertSvgToImage(string svgContent, string outputPath, ImageFormat format)
    {
        ImageSaveOptions options = new ImageSaveOptions(format);
        // Base URI is required for inline SVG content; using a dummy value.
        Aspose.Html.Converters.Converter.ConvertSVG(svgContent, "about:blank", options, outputPath);
    }

    static void ConvertSvgToPdf(string svgContent, string outputPath)
    {
        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
        // Base URI is required for inline SVG content; using a dummy value.
        Aspose.Html.Converters.Converter.ConvertSVG(svgContent, "about:blank", options, outputPath);
    }
}