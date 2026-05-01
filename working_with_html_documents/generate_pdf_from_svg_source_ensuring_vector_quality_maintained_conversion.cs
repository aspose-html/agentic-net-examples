// Generate a PDF from an SVG source, ensuring vector quality is maintained during conversion.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace SvgToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "input.svg";
                string outputPath = "output.pdf";
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertSVG(sourcePath, options, outputPath);
                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}