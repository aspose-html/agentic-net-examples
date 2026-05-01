// Render an SVG diagram to a PDF and embed it as a vector object within the document.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path
            string svgPath = "diagram.svg";
            // Output PDF file path
            string pdfPath = "diagram.pdf";

            // Initialize PDF save options with default settings
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert the SVG to a PDF preserving vector graphics
            Converter.ConvertSVG(svgPath, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}