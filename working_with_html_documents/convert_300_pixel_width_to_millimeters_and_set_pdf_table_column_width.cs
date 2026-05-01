// Convert 300 pixel width to millimeters and use the result to set column width in PDF tables.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define the column width in pixels
            double columnWidthPixels = 300;

            // Convert pixels to millimeters (96 DPI, 25.4 mm per inch)
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;

            // Build an HTML string with a table and set the column width using the calculated mm value
            string html = $"<html><body>" +
                          $"<table>" +
                          $"<col style='width:{columnWidthMillimeters:F2}mm;'>" +
                          $"<tr><td>Cell 1</td><td>Cell 2</td></tr>" +
                          $"</table>" +
                          $"</body></html>";

            // Base URI can be empty because the HTML is self‑contained
            string baseUri = "";

            // PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // Output PDF file path
            string outputPath = "output.pdf";

            // Convert the HTML content to PDF
            Converter.ConvertHTML(html, baseUri, options, outputPath);

            Console.WriteLine($"PDF generated with column width {columnWidthMillimeters:F2} mm.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}