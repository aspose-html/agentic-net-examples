// Use ConvertHTML to transform an HTML string directly to PDF without creating an HTMLDocument instance.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello World</h1></body></html>";
            string baseUrl = "";
            PdfSaveOptions options = new PdfSaveOptions();
            string outputPath = "output.pdf";
            Converter.ConvertHTML(html, baseUrl, options, outputPath);
            Console.WriteLine("PDF created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}