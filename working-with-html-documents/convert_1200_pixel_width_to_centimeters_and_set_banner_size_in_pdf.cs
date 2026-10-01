// Convert 1200 pixel width to centimeters and use the value to set banner size in PDF.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 1200 pixels to centimeters
            double widthPixels = 1200;
            const double ppi = 96.0;
            double widthInches = widthPixels / ppi;
            double widthCentimeters = widthInches * 2.54;
            Console.WriteLine($"Width in centimeters: {widthCentimeters:F2} cm");

            // Create a simple HTML document (banner placeholder)
            string htmlContent = "<html><body><div style='width:1200px;height:200px;background:#ff0000;'>Banner</div></body></html>";
            var document = new Aspose.Html.HTMLDocument();
            document.Write(htmlContent);

            // Set PDF page size using the converted width (in inches)
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            // Height is arbitrary (e.g., 2 inches)
            double heightInches = 2.0;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(widthInches),
                    Aspose.Html.Drawing.Length.FromInches(heightInches)),
                new Aspose.Html.Drawing.Margin());

            // Render to PDF
            string outputPath = "banner.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}