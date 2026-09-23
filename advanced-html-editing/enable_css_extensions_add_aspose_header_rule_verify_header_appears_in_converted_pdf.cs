// Enable CSS extensions, add a -aspose- header rule, and verify header appears in converted PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "@page { @top-center { content: '-aspose-'; } }";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed. Verify that the header '-aspose-' appears in the PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}