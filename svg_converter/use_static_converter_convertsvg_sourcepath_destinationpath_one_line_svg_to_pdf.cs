// Use static Converter.ConvertSVG(sourcePath, destinationPath) for one‑line SVG to PDF conversion.

using System;

namespace SvgToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source SVG file
                string sourcePath = "example.svg";

                // PDF conversion options (default settings)
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Path for the resulting PDF file
                string outputPath = "example.pdf";

                // Perform the conversion from SVG to PDF
                Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

                Console.WriteLine("SVG has been successfully converted to PDF.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}