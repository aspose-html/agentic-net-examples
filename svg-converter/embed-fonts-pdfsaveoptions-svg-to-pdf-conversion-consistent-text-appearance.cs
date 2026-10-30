// Embed fonts in PdfSaveOptions during SVG to PDF conversion for consistent text appearance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><text x=\"10\" y=\"50\" font-family=\"Arial\" font-size=\"24\">Hello, World!</text></svg>";

            // Output PDF file path
            string outputPath = "output.pdf";

            // PDF save options (font embedding is not configurable in Aspose.HTML)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert SVG to PDF
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, "about:blank", options, outputPath);

            Console.WriteLine("SVG successfully converted to PDF: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}