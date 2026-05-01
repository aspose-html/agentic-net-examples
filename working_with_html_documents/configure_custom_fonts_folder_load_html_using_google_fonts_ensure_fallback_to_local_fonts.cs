// Configure custom fonts folder, load HTML using Google Fonts, and ensure fallback to local fonts.

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
            // Paths for the HTML source, custom fonts folder, and output PDF
            string htmlPath = "input.html";
            string fontsFolder = "fonts";
            string outputPdf = "output.pdf";

            // Create a configuration object to hold rendering settings
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Retrieve the user agent service from the configuration
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

            // Configure the service to use the custom fonts lookup folder
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document using the configured settings
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Create default PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF, embedding fonts from the custom folder
                Converter.ConvertHTML(document, options, outputPdf);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}