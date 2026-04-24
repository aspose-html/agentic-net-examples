// Convert HTML to PNG with custom CSS font fallback to ensure text renders when primary font missing.

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
            // Create a configuration object to hold conversion settings
            Configuration configuration = new Configuration();

            // Retrieve the user agent service from the configuration
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));

            // Specify the folder that contains custom fonts (recursive search enabled)
            userAgentService.FontsSettings.SetFontsLookupFolder("fonts", true);

            // Load the HTML document using the configuration that includes the custom font settings
            using (HTMLDocument document = new HTMLDocument("input.html", configuration))
            {
                // Create default image save options (PNG will be used by default)
                ImageSaveOptions options = new ImageSaveOptions();

                // Convert the HTML document to a PNG image
                Converter.ConvertHTML(document, options, "output.png");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}