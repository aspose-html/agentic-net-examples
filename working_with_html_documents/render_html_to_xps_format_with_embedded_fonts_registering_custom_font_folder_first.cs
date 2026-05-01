// Render HTML to XPS format with embedded fonts by registering custom font folder first.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;

namespace HtmlToXpsWithCustomFonts
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the HTML file to be converted
                string htmlPath = @"C:\Input\sample.html";

                // Path to the folder that contains custom fonts
                string fontsFolder = @"C:\Fonts";

                // Path where the resulting XPS file will be saved
                string outputPath = @"C:\Output\sample.xps";

                // Create a configuration object to hold rendering settings
                Configuration configuration = new Configuration();

                // Retrieve the user agent service from the configuration
                IUserAgentService userAgentService = configuration.GetService<IUserAgentService>();

                // Register the custom fonts folder so that fonts are embedded in the XPS
                userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

                // Load the HTML document using the configured environment
                HTMLDocument document = new HTMLDocument(htmlPath, configuration);

                // Create default XPS save options (fonts will be embedded automatically)
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion: HTML -> XPS
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}