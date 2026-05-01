// Configure a custom user style sheet, load a remote HTML page, and render it to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Custom CSS to be applied to the HTML content
            string css = "h1 { color: blue; } p { font-size: 14px; }";

            // Remote HTML page URL
            string url = "https://www.example.com";

            // Path for the generated PDF file
            string outputPdf = "output.pdf";

            // Create a configuration object
            Aspose.Html.Configuration configuration = Aspose.Html.Configuration.Create();

            // Retrieve the user agent service from the configuration
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

            // Assign the custom stylesheet to the user agent service
            userAgentService.UserStyleSheet = css;

            // Load the remote HTML document using the configured settings
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration);

            // Create PDF save options (default settings)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert the HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}