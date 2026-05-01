// Load HTML from a string containing Unicode characters, set appropriate encoding, and render to PDF.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body><p>Unicode test: 測試, тест, اختبار</p></body></html>";
            string baseUri = "";
            PdfSaveOptions options = new PdfSaveOptions();
            string outputPath = "output.pdf";
            Converter.ConvertHTML(html, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}