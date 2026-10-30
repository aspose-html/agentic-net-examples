// Provide a base URL to ConvertHTML to correctly resolve relative links and resources during PDF generation.

using System;

namespace HTMLToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><head><title>Test</title></head><body><h1>Hello World</h1><img src='images/logo.png' alt='Logo'></body></html>";
                string baseUrl = "https://example.com/";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("PDF generated successfully at " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}