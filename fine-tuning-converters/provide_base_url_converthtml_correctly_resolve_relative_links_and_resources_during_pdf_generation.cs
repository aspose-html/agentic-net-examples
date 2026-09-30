// Provide a base URL to ConvertHTML to correctly resolve relative links and resources during PDF generation.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><head><title>Test</title></head><body><img src='images/pic.png' alt='Sample Image'/><p>Hello World!</p></body></html>";
            string baseUrl = "https://example.com/";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF generated successfully at " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}