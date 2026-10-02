// Convert 900 pixel height to points and apply it to set paragraph spacing in PDF output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 900 pixels to points (assuming 96 DPI)
            double points = 900 * 72.0 / 96.0;
            string paragraphStyle = $"margin-top:{points}pt;margin-bottom:{points}pt;";

            string html = $"<html><head><style>p{{{paragraphStyle}}}</style></head><body><p>This paragraph has spacing of 900px converted to points.</p></body></html>";

            // Load HTML content
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Set PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}