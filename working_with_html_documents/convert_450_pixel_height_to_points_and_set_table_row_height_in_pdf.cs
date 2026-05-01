// Convert 450 pixel height to points and use the result to set table row height in PDF.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            double heightPixels = 450;
            double heightPoints = heightPixels * 72.0 / 96.0;

            string html = $"<html><body>" +
                          $"<table border='1' style='border-collapse:collapse;'>" +
                          $"<tr style='height:{heightPoints}pt;'><td>Row height set to {heightPoints:F2}pt</td></tr>" +
                          $"</table>" +
                          $"</body></html>";

            // Create HTMLDocument from the HTML string
            HTMLDocument document = new HTMLDocument(html, ".");

            // Configure PDF save options (default options are sufficient for this example)
            PdfSaveOptions options = new PdfSaveOptions();

            string outputPath = "output.pdf";

            // Convert HTML document to PDF
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}