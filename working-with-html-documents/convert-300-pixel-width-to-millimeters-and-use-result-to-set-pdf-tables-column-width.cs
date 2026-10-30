// Convert 300 pixel width to millimeters and use the result to set column width in PDF tables.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double columnWidthPixels = 300;
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            System.Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");

            string html = $"<html><body><table border='1'><tr><td style='width:{columnWidthMillimeters:F2}mm'>Column with width {columnWidthMillimeters:F2} mm</td></tr></table></body></html>";

            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            string outputPath = "output.pdf";

            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine($"PDF generated at {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}