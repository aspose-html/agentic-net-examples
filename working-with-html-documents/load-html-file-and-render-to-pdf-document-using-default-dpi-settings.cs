// Load an HTML file and render it to a PDF document using default DPI settings.

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
                System.IO.File.WriteAllText(
                    inputPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>"
                );
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