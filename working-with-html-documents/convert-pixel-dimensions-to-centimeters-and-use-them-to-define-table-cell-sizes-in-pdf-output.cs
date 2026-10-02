// Convert pixel dimensions to centimeters and use them to define table cell sizes in PDF output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double columnWidthPixels = 200.0;
            double rowHeightPixels = 100.0;
            const double ppi = 96.0;

            // Convert to centimeters
            double columnWidthCentimeters = columnWidthPixels / ppi * 2.54;
            double rowHeightCentimeters = rowHeightPixels / ppi * 2.54;

            System.Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthCentimeters:F2} cm");
            System.Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightCentimeters:F2} cm");

            // Build HTML with table using converted sizes
            string html = $"<html><body>" +
                          $"<table border='1' style='border-collapse:collapse;'>" +
                          $"<tr>" +
                          $"<td style='width:{columnWidthCentimeters:F2}cm; height:{rowHeightCentimeters:F2}cm; text-align:center; vertical-align:middle;'>Cell</td>" +
                          $"</tr>" +
                          $"</table>" +
                          $"</body></html>";

            // Load HTML document (inline content)
            using (var document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                // Set up PDF rendering options
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

                // Define page size (Letter) and margins (1 inch)
                var pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11));
                var margin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(1), // top
                    Aspose.Html.Drawing.Length.FromInches(1), // right
                    Aspose.Html.Drawing.Length.FromInches(1), // bottom
                    Aspose.Html.Drawing.Length.FromInches(1)  // left
                );
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, margin);

                // Render to PDF file
                string outputPath = "output.pdf";
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine($"PDF generated successfully at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}