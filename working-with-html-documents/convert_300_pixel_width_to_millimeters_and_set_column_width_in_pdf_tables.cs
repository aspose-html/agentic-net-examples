// Convert 300 pixel width to millimeters and use the result to set column width in PDF tables.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 300 pixels to millimeters (96 DPI assumed)
            double pixels = 300;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;

            // Create simple HTML with a table column width set in millimeters
            string html = $"<html><body><table border='1'><col style='width:{millimeters:F2}mm;'><tr><td>Sample Cell</td></tr></table></body></html>";

            // Load HTML into Aspose.Html document
            var document = new Aspose.Html.HTMLDocument(html);

            // Configure PDF rendering options with a standard page size
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11)));

            // Render the document to a PDF file
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"Converted {pixels} px to {millimeters:F2} mm and saved PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}