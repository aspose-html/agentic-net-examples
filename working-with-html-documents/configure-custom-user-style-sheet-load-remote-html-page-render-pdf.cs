// Configure a custom user style sheet, load a remote HTML page, and render it to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Remote HTML page URL
            string url = "https://example.com";

            // Custom user style sheet
            string customCss = "body { background-color: #f0f0f0; }";

            // Create configuration and set the user style sheet
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)config.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.UserStyleSheet = customCss;

            // Load the remote HTML document with the custom configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, config);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Output PDF file path
            string outputPath = "output.pdf";

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"PDF successfully saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}