// Apply PageSetup scaling factor of 0.75 to reduce page size during PDF conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Create HTML document from content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options with scaled page size (75% of original 800x600)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page()
            {
                Size = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromPixels(600), // 800 * 0.75
                    Aspose.Html.Drawing.Length.FromPixels(450)  // 600 * 0.75
                )
            };

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF conversion completed successfully. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during PDF conversion: " + ex.Message);
        }
    }
}