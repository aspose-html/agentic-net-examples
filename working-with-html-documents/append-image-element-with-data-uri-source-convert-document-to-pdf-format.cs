// Append an image element with a data URI source, then convert the document to PDF format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body></body></html>";
            string baseUrl = "about:blank";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);

            // Data URI for a small red dot PNG image
            string dataUri = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+X9WcAAAAASUVORK5CYII=";

            // Create <img> element and set its src attribute
            Aspose.Html.HTMLElement imgElement = (Aspose.Html.HTMLElement)document.CreateElement("img");
            imgElement.SetAttribute("src", dataUri);

            // Append the image to the document body
            document.Body.AppendChild(imgElement);

            // Prepare PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}