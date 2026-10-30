// Use HtmlRenderer.RenderToPdf with custom page size options derived from pixel measurements.

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
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            // Base URI for relative resources (not needed here)
            string baseUri = new Uri(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar).AbsoluteUri;

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Configure PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}