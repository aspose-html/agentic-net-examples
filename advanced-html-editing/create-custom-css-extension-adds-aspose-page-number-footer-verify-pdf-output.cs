// Create a custom CSS extension that adds a -aspose- page‑number footer, and verify in PDF output.

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

            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                 "<h1>Sample Document</h1>" +
                                 "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>" +
                                 "<p>More content to generate multiple pages.</p>" +
                                 "<p style='page-break-before:always;'>Second page content.</p>" +
                                 "<p>End of document.</p>" +
                                 "</body></html>";

            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "@page { @bottom-center { content: '-aspose-page-number'; } }";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully. Output: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}