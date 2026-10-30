// Generate PDF files from HTML pages, embedding metadata such as author and creation date.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "sample.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}