// Convert 1200 pixel width to centimeters and use the value to set banner size in PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel value
            double widthPixels = 1200;
            const double ppi = 96.0;

            // Convert to centimeters
            double widthInches = widthPixels / ppi;
            double widthCentimeters = widthInches * 2.54;

            Console.WriteLine($"Width: {widthPixels} px = {widthCentimeters:F2} cm");

            // Sample HTML with a banner
            string htmlContent = @"
                <html>
                    <body>
                        <div style='width:1200px;height:200px;background:#4CAF50;color:white;font-size:24px;display:flex;align-items:center;justify-content:center;'>
                            Sample Banner
                        </div>
                    </body>
                </html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define zero margins
            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromCentimeters(0),
                Aspose.Html.Drawing.Length.FromCentimeters(0),
                Aspose.Html.Drawing.Length.FromCentimeters(0),
                Aspose.Html.Drawing.Length.FromCentimeters(0));

            // Set page size using the calculated width and a fixed height (e.g., 5 cm)
            double pageHeightCentimeters = 5.0;
            var page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromCentimeters(widthCentimeters),
                    Aspose.Html.Drawing.Length.FromCentimeters(pageHeightCentimeters)),
                margin);

            // Configure PDF rendering options
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = page;

            // Output PDF path
            string outputPath = "banner.pdf";

            // Render to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}