// Configure custom fonts folder, load HTML using web fonts, and ensure fallback fonts are applied.

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
            // Paths for the HTML file, custom fonts folder, and output PDF
            string htmlPath = "input.html";
            string fontsFolder = "fonts";
            string outputPdf = "output.pdf";

            // Create a configuration object to hold rendering settings
            Configuration configuration = new Configuration();

            // Retrieve the user agent service from the configuration
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));

            // Set the custom fonts lookup folder
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document using the configured settings
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Create default PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF, applying the custom fonts
                Converter.ConvertHTML(document, options, outputPdf);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}