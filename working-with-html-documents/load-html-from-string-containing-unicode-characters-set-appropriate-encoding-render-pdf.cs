// Load HTML from a string containing Unicode characters, set appropriate encoding, and render to PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Unicode Test</title></head><body><p>Привет, мир! こんにちは世界 🌍</p></body></html>";
            string outputPath = "unicode_output.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(html, "about:blank", options, outputPath);

            Console.WriteLine("PDF created successfully at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}