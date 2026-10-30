// Apply PageSetup scaling factor of 0.75 to reduce page size during PDF conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";

            // Load HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options with scaled page size (75% of default A4 approx 595x842 points)
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Calculate scaled dimensions
            int scaledWidth = (int)(595 * 0.75);   // 446
            int scaledHeight = (int)(842 * 0.75);  // 631

            // Set page setup with scaled size
            var page = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(scaledWidth, scaledHeight));
            options.PageSetup.AnyPage = page;

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}