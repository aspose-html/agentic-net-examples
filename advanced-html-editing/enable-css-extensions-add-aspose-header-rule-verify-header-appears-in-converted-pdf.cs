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
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "-aspose-header: \"Sample Header\";";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed. Header should appear in the PDF.");
            Console.WriteLine("Note: Verifying the header requires a PDF parsing library, which is not included in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}