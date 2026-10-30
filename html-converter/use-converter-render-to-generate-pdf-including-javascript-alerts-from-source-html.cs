// Use Converter.RenderTo with PdfDevice to generate a PDF that includes JavaScript alerts from the source HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with JavaScript alert
            string htmlContent = "<!DOCTYPE html><html><head><script type='text/javascript'>function show(){alert('Hello from JS');}</script></head><body onload='show()'>PDF with JavaScript alert</body></html>";

            // Enable script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load HTML document from string (use base URI to avoid file‑path interpretation)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", config);

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML document to PDF
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine($"PDF generated successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}