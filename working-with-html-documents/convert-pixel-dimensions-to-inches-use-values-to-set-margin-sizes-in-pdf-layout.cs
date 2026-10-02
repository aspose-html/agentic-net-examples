// Convert pixel dimensions to inches and use the values to set margin sizes in a PDF layout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample pixel dimensions for margins
            int leftPixels = 72;
            int topPixels = 96;
            int rightPixels = 72;
            int bottomPixels = 96;

            // Convert pixels to inches (96 DPI)
            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            // Create margin using inches
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),
                Aspose.Html.Drawing.Length.FromInches(rightInches),
                Aspose.Html.Drawing.Length.FromInches(bottomInches),
                Aspose.Html.Drawing.Length.FromInches(leftInches));

            // Set up PDF rendering options with page size and margins
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Output PDF file path
            string outputPath = "output.pdf";

            // Render HTML to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}