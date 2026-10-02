// Convert pixel width to centimeters and use the result to set column widths in a PDF table.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel value for column width
            double columnWidthPixels = 200.0;
            // Convert pixels to centimeters (96 PPI, 1 inch = 2.54 cm)
            double columnWidthCentimeters = columnWidthPixels / 96.0 * 2.54;

            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthCentimeters:F2} cm");

            // Build simple HTML with a table using the calculated width in cm
            string htmlContent = $"<html><body>" +
                                 $"<table style='border-collapse:collapse;'>" +
                                 $"<colgroup>" +
                                 $"<col style='width:{columnWidthCentimeters:F2}cm;'/>" +
                                 $"<col style='width:{columnWidthCentimeters:F2}cm;'/>" +
                                 $"</colgroup>" +
                                 $"<tr><td style='border:1px solid #000;'>Cell 1</td><td style='border:1px solid #000;'>Cell 2</td></tr>" +
                                 $"</table>" +
                                 $"</body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set up PDF rendering options with default page size and margins
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1));

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            // Render to PDF file
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}