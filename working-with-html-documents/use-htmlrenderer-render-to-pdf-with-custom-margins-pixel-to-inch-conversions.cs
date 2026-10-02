// Use HtmlRenderer.RenderToPdf with custom margins derived from pixel‑to‑inch conversions for the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                // Pixel margins
                double leftPixels = 48;
                double topPixels = 72;
                double rightPixels = 48;
                double bottomPixels = 72;

                // Convert pixels to inches (96 DPI)
                double leftInches = leftPixels / 96.0;
                double topInches = topPixels / 96.0;
                double rightInches = rightPixels / 96.0;
                double bottomInches = bottomPixels / 96.0;

                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(topInches),
                    Aspose.Html.Drawing.Length.FromInches(rightInches),
                    Aspose.Html.Drawing.Length.FromInches(bottomInches),
                    Aspose.Html.Drawing.Length.FromInches(leftInches));

                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11));

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
                options.PageSetup.AnyPage = page;

                string outputPath = "output.pdf";

                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}