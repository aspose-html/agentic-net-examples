// Create a custom CSS extension that adds a -aspose- page‑number footer, and verify in PDF output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a simple HTML file with enough content for multiple pages
            string htmlContent = "<!DOCTYPE html><html><head><title>Page Number Test</title></head><body>" +
                                 "<h1>Page Number Footer Example</h1>" +
                                 "<p>" + new string('A', 5000) + "</p>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create configuration and enable custom CSS extension via UserStyleSheet
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            // CSS extension that adds a page number footer using -aspose-page-number
            userAgent.UserStyleSheet = "@page { @bottom-center { content: counter(page); -aspose-page-number: true; } }";

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Set PDF save options (default options are sufficient)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully. Output file: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}