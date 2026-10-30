// Create a document, embed a base64‑encoded image, and export to PDF ensuring image renders.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Base64 Image</h1><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=\" alt=\"Red dot\"/></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}