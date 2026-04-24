// Load SVG markup from a string and convert it to PDF with high precision using PdfDevice.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // SVG markup to be converted
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // PDF conversion options (default high‑precision settings)
            PdfSaveOptions options = new PdfSaveOptions();

            // Destination PDF file
            string outputPath = "output.pdf";

            // Convert the SVG string to PDF
            Converter.ConvertSVG(svgCode, ".", options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}