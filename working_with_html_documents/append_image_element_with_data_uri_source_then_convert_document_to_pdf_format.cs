// Append an image element with a data URI source, then convert the document to PDF format.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Create an HTML document with a basic structure
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body></body></html>";
            string baseUrl = "";
            HTMLDocument document = new HTMLDocument(htmlContent, baseUrl);

            // Append an image element with a data URI source
            var img = document.CreateElement("img");
            img.SetAttribute("src", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAn0B9pVYVwAAAABJRU5ErkJggg==");
            document.Body.AppendChild(img);

            // Configure PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Define output PDF path
            string outputPath = "output.pdf";

            // Convert the HTML document to PDF
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}