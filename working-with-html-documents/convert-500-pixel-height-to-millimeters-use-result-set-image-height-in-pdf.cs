// Convert 500 pixel height to millimeters and use the result to set image height in PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 500.0;
            double heightPixels = 500.0;
            const double ppi = 96.0;

            // Convert to millimeters
            double widthMillimeters = (widthPixels / ppi) * 25.4;
            double heightMillimeters = (heightPixels / ppi) * 25.4;

            Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            Console.WriteLine($"Height: {heightMillimeters:F2} mm");

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello PDF</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set PDF page size using converted dimensions
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)));

            // Convert HTML to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}