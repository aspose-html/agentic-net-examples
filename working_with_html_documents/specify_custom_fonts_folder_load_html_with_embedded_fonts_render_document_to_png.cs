// Specify a custom fonts folder, load HTML with embedded fonts, and render the document to PNG.

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
            // Create configuration object
            Configuration configuration = new Configuration();

            // Retrieve the user agent service to configure fonts
            IUserAgentService service = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));

            // Set custom fonts lookup folder (recursive)
            service.FontsSettings.SetFontsLookupFolder("fonts", true);

            // Load HTML document with the configured settings
            HTMLDocument document = new HTMLDocument("input.html", configuration);

            // Define image save options (defaults)
            ImageSaveOptions options = new ImageSaveOptions();

            // Convert HTML to PNG image
            Converter.ConvertHTML(document, options, "output.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}