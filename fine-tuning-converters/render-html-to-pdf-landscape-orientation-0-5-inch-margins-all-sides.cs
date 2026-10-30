// Render HTML to PDF with custom page orientation set to Landscape and 0.5‑inch margins on all sides.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Define page size (Landscape A4) and 0.5‑inch margins (36 points)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(11.69),
                Aspose.Html.Drawing.Length.FromInches(8.27));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(36, 36, 36, 36);

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

            // Set PDF save options with custom page setup
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.PageSetup.AnyPage = page;

            // Output PDF path
            string outputPath = "output.pdf";

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF successfully created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}