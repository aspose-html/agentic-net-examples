// Load HTML from a string containing Unicode characters, set appropriate encoding, and render to PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Unicode Test</title></head><body><h1>Привет мир 🌍</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("PDF successfully created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}