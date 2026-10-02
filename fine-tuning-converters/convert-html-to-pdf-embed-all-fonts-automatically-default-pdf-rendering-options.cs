// Convert HTML to PDF and embed all fonts automatically by relying on default PdfRenderingOptions behavior.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This PDF includes embedded fonts.</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}