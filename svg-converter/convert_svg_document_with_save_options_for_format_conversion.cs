// Call Converter.ConvertSVG with SVGDocument and save options to perform format conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Sample SVG content
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Convert SVG to JPEG
            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            string jpegPath = Path.Combine(outputDir, "output.jpg");
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, jpegOptions, jpegPath);

            // Convert SVG to PDF
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            string pdfPath = Path.Combine(outputDir, "output.pdf");
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, pdfOptions, pdfPath);

            // Convert SVG to XPS
            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            string xpsPath = Path.Combine(outputDir, "output.xps");
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, xpsOptions, xpsPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}