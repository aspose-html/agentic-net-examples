// Dispose SVGDocument and all associated streams after conversion to prevent memory leaks.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string sourcePath = "input.svg";
            // Desired output PDF file path
            string outputPath = "output.pdf";

            // Load the SVG document inside a using block to ensure it is disposed
            using (SVGDocument document = new SVGDocument(sourcePath))
            {
                // Create PDF save options (default settings)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the SVG document to PDF and write directly to the output file
                Converter.ConvertSVG(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}