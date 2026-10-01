// Configure a custom user style sheet, load a remote HTML page, and render it to PDF.

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

            // Create a simple HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create configuration and set a user style sheet
            Aspose.Html.Configuration configuration = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.UserStyleSheet = "body { font-family: Arial; }";

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Set PDF save options (default options are sufficient for this example)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine($"Conversion completed successfully. PDF saved to '{pdfPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}