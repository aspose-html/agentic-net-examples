// Set a custom font lookup folder using FontsSettings.SetFontsLookupFolder before rendering HTML.

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
            // Define file and folder paths
            string htmlPath = "input.html";
            string fontsFolder = "fonts";
            string pdfPath = "output.pdf";

            // Create a configuration object to hold rendering settings
            Configuration configuration = new Configuration();

            // Retrieve the user agent service from the configuration
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));

            // Set the custom fonts lookup folder
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document using the configured environment
            HTMLDocument document = new HTMLDocument(htmlPath, configuration);

            // Initialize PDF save options (default settings)
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert the HTML document to PDF, applying the custom fonts
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}